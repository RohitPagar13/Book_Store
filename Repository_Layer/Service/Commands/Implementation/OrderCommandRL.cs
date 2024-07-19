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
        public async Task<OrderResponseModel> PlaceOrderAnync(int userId, int userDetailsId)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var carts = await _db.Carts.Where(c=>c.UserEntityId==userId).ToListAsync();
                    if (carts == null || carts.Any(c=>c.IsInStock))
                    {
                        throw new BookStoreException("Unable to place order as Cart is Empty or some items in cart are out of stock");
                    }

                    List<OrderEntity> orders = new List<OrderEntity>();

                    double totalPrice = 0;
                    foreach(var item in carts)
                    {
                        OrderEntity orderEntity = new OrderEntity
                        {
                            UserDetailsEntityId = userDetailsId,
                            TotalOrderPrice = item.CartPrice
                        };
                        await _db.Orders.AddRangeAsync(orderEntity);
                        totalPrice = totalPrice + item.CartPrice;
                        orders.Add(orderEntity);
                    }
                    OrderResponseModel orderResponseModel = new OrderResponseModel
                    {
                        Orders = orders,
                        TotalPrice = totalPrice+99,
                    };
                    await _db.Orders.AddRangeAsync(orders);
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
    }
}
