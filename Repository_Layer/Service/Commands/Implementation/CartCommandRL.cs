using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model_Layer.RequestModel;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Implementation
{
    public class CartCommandRL : ICartCommandRL
    {
        private readonly Book_Store_Context _db;
        public CartCommandRL(Book_Store_Context db)
        {
            _db = db;
        }
        public async Task<CartEntity> AddToCartAsync(CartModel cartModel)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (_db.Carts.AnyAsync(c => c.BookEntityId == cartModel.BookId && c.UserEntityId== cartModel.UserId).Result)
                    {
                        throw new BookStoreException("Book with specified Id Already added to the Cart");
                    }
                    var book = await _db.Books.FindAsync(cartModel.BookId);
                    if (book.StockQuantity < 1)
                    {
                        throw new BookStoreException("Book is out of Stock");
                    }
                    CartEntity cart = new CartEntity
                    {
                        BookEntityId = cartModel.BookId,
                        Quantity = 1,
                        CartPrice = book.Price,
                        UserEntityId = cartModel.UserId
                    };

                    await _db.Carts.AddAsync(cart);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return cart;
                }
                catch (SqlException se)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }

        public async Task<CartEntity> DeleteCartAsync(int cartId)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var cart = await _db.Carts.FindAsync(cartId);
                    if (cart==null)
                    {
                        throw new BookStoreException("Cart with specified Id does not exist");
                    }
                    _db.Carts.Remove(cart);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return cart;
                }
                catch (SqlException se)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }

        public async Task<CartEntity> UpdateCartAsync(int cartId, int Quantity)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var cart = await _db.Carts.FindAsync(cartId);
                    if (cart==null)
                    {
                        throw new BookStoreException("Cart with specified Id does not Exists");
                    }
                    var book = await _db.Books.FindAsync(cart.BookEntityId);
                    if(book.StockQuantity<Quantity)
                    {
                        throw new BookStoreException("Only " + book.StockQuantity + " left in the stock");
                    }
                    cart.Quantity = Quantity;
                    cart.CartPrice = book.Price * Quantity;

                    _db.Carts.Update(cart);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return cart;
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
