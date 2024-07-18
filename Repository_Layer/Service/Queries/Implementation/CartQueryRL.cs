using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<CartEntity>> GetAllCartsForUserAsync(int userId)
        {
            try
            {
                var result = await _db.Carts.Where(c=>c.UserId==userId).ToListAsync();

                foreach (var item in result)
                {
                    var book = await _db.Books.FindAsync(item.BookId);
                    if (book.StockQuantity < 1)
                    {
                        item.IsInStock = false;
                    }
                    else
                    {
                        item.IsInStock = true;
                    }
                }
                if (result != null)
                {
                    return result;
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
