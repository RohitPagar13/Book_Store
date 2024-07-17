using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using RepositoryLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Implementation
{
    public class BookCommandRL : IBookCommandRL
    {
        private readonly Book_Store_Context _db;
        public BookCommandRL(Book_Store_Context db)
        {
            _db = db;
        }
        public async Task<BookEntity> AddBookAsync(BookEntity book)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (_db.Books.Any(b => b.Title.Equals(book.Title) || b.ISBN.Equals(book.ISBN)))
                    {
                        throw new BookStoreException("Book with specified Title or ISBN Already Exists");
                    }

                    await _db.Books.AddAsync(book);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return book;
                }
                catch (SqlException se)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }

        public async Task<BookEntity> DeleteBookAsync(int bookId)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    BookEntity? book = await _db.Books.FindAsync(bookId);
                    if (book==null)
                    {
                        throw new BookStoreException("Book with specified Id does not Exists");
                    }

                    _db.Books.Remove(book);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return book;
                }
                catch (SqlException se)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }

        public async Task<BookEntity> UpdateBookAsync(BookEntity book)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (!_db.Books.AnyAsync(b => b.BookId.Equals(book.BookId)).Result)
                    {
                        throw new BookStoreException("Book with specified Id does not Exists");
                    }

                    _db.Books.Update(book);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return book;
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
