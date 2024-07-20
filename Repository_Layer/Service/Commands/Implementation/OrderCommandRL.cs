using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model_Layer.RequestModel;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using Repository_Layer.Models;
using Repository_Layer.Service.Commands.Command_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Implementation
{
    public class OrderCommandRL : IOrderCommandRL
    {
        private readonly Book_Store_Context _db;
        public OrderCommandRL(Book_Store_Context db)
        {
            _db = db;
        }
        public async Task<OrderResponseModel> PlaceOrderAsync(PlaceOrderModel orderModel)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var carts = await _db.Carts.Where(c=>c.UserEntityId== orderModel.UserId).ToListAsync();
                    if (carts == null || carts.Any(c=>c.IsInStock || c.Quantity<=0))
                    {
                        throw new BookStoreException("Unable to place order as Cart is Empty or some items in cart are out of stock or Qunatity is less than required");
                    }

                    List<OrderEntity> orders = new List<OrderEntity>();

                    double totalPrice = 0;

                    List<BookEntity> books = new List<BookEntity>();

                    foreach(var item in carts)
                    {
                        var book = _db.Books.Where(b=>b.BookId==item.BookEntityId).FirstAsync().Result;
                        if (book.StockQuantity >= item.Quantity)
                        {
                            book.StockQuantity -= item.Quantity;
                        }
                        else
                        {
                            throw new BookStoreException("Unable to place order as Qunatity is less than required");
                        }
                        OrderEntity orderEntity = new OrderEntity
                        {
                            BookEntityId = book.BookId,
                            UserDetailsEntityId = orderModel.UserDetailsId,
                            OrderPrice = item.CartPrice,
                            Quantity = item.Quantity,
                        };

                        totalPrice+= item.CartPrice;

                        books.Add(book);
                        orders.Add(orderEntity);
                    }
                    OrderResponseModel orderResponseModel = new OrderResponseModel
                    {
                        Orders = orders,
                        TotalPrice = totalPrice+99,
                    };

                    _db.Books?.UpdateRange(books);
                    await _db.Orders.AddRangeAsync(orders);
                    _db.Carts.RemoveRange(carts);

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return orderResponseModel;
                }
                catch (SqlException se)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }

        public async Task<OrderEntity> CancelOrderAsync(int orderId)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var order = await _db.Orders.Where(o => o.OrderId == orderId).FirstAsync();
                    if (order == null)
                    {
                        throw new BookStoreException("Unable to Cancel Order");
                    }

                    var book = await _db.Books.FindAsync(order.BookEntityId);

                    book.StockQuantity += order.Quantity;

                    _db.Books.Update(book);
                    _db.Orders.Remove(order);

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return order;
                }
                catch (SqlException se)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }

        public async Task<OrderEntity> BuyNowAsync(BuyNowModel buyNowModel)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var book = await _db.Books.FindAsync(buyNowModel.BookId);
                    if (book.StockQuantity < 1)
                    {
                        throw new BookStoreException("Unable to place order. Product is Out of Stock");
                    }

                    OrderEntity orderEntity = new OrderEntity
                    {
                        BookEntityId = buyNowModel.BookId,
                        UserDetailsEntityId = buyNowModel.UserDetailsId,
                        OrderPrice = book.Price,
                        Quantity = 1,
                    };

                    book.StockQuantity--;

                    await _db.Orders.AddAsync(orderEntity);
                    _db.Books.Update(book);

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return orderEntity;
                }
                catch (SqlException se)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }
    }
}
