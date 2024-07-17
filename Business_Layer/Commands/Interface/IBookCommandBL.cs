using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Interface
{
    public interface IBookCommandBL
    {
        public Task<BookEntity> AddBookAsync(BookModel bookModel);
        public Task<BookEntity> UpdateBookAsync(int bookId, BookModel bookModel);
        public Task<BookEntity> DeleteBookAsync(int bookId);
    }
}
