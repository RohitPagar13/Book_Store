using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Command_Interface
{
    public interface IBookCommandRL
    {
        public Task<BookEntity> AddBookAsync(BookModel bookModel);
        public Task<BookEntity> UpdateBookAsync(BookModel bookModel);

        public Task<BookEntity> DeleteBookAsync(int bookId);
    }
}
