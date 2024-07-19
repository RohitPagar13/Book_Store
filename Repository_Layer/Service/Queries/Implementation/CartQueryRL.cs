using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model_Layer.ResponseModel;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Queries.Implementation
{
    public class CartQueryRL : ICartQueryRL
    {
        private readonly Book_Store_Context _db;

        public CartQueryRL(Book_Store_Context db)
        {
            _db = db;
        }
        public async Task<CartResponseModel> GetAllCartsForUserAsync(int userId)
        {
            try
            {
                CartResponseModel UserCart = new CartResponseModel();
                UserCart.AllCartsforUser = await _db.Carts.Where(c=>c.UserEntityId==userId).ToListAsync();
                UserCart.TotalCartPrice = UserCart.AllCartsforUser.GroupBy(x => x.UserEntityId).Select(group => group.Sum(item => item.CartPrice)).Sum();
                UserCart.TotalPrice = UserCart.TotalCartPrice + UserCart.deliveryFee;

                foreach (var item in UserCart.AllCartsforUser)
                {
                    var book = await _db.Books.FindAsync(item.BookEntityId);
                    if (book.StockQuantity < 1)
                    {
                        item.IsInStock = false;
                    }
                    else
                    {
                        item.IsInStock = true;
                    }
                }
                if (UserCart != null)
                {
                    return UserCart;
                }
                throw new BookStoreException("No Data found");
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.ToString());
                throw;
            }
        }
    }
}
