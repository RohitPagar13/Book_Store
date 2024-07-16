using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class BookQueryRL : IBookQueryRL
    {
        private readonly Book_Store_Context _db;

        public BookQueryRL(Book_Store_Context db)
        {
            _db = db;
        }
        public async Task<List<BookEntity>> getAllBookAsync()
        {
            try
            {
                var result = await _db.Books.ToListAsync();
                if (result != null)
                {
                    return result;
                }
                throw new BookStoreException("No data found");
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.ToString());
                throw;
            }
        }

        public async Task<BookEntity> getBookByIdAsync(int bookId)
        {
            try
            {
                var result = await _db.Books.Where(b=>b.BookId==bookId).FirstAsync();
                if (result != null)
                {
                    return result;
                }
                throw new BookStoreException("No data found");
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.ToString());
                throw;
            }
        }
    }
}
