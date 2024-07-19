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
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Implementation
{
    public class WishListCommandRL : IWishListCommandRL
    {
        private readonly Book_Store_Context _db;
        public WishListCommandRL(Book_Store_Context db)
        {
            _db = db;
        }
        public async Task<WishListEntity> addToWishListAsync(WishListModel wishListModel)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (_db.WishList.AnyAsync(c => c.BookId == wishListModel.BookId && c.UserId == wishListModel.UserId).Result)
                    {
                        throw new BookStoreException("Book Already in the WishList");
                    }
                    
                    WishListEntity wishList = new WishListEntity
                    {
                        BookId = wishListModel.BookId,
                        UserId = wishListModel.UserId
                    };

                    var book = await _db.Books.FindAsync(wishListModel.BookId);

                    if (book.StockQuantity < 1)
                    {
                        wishList.IsInStock = false;
                    }
                    else
                    {
                        wishList.IsInStock = true;
                    }
                    await _db.WishList.AddAsync(wishList);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return wishList;
                }
                catch (SqlException se)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }

        public async Task<WishListEntity> removeFromWishListAsync(int wishListId)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var wishList = await _db.WishList.FindAsync(wishListId);
                    if (wishList==null)
                    {
                        throw new BookStoreException("WishList does not exists");
                    }

                    _db.WishList.Remove(wishList);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return wishList;
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
