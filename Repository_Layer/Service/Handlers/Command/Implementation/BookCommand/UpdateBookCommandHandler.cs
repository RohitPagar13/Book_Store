using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Implementation.BookCommand
{
    public class UpdateBookCommandHandler : IUpdateCommandHandler<int, BookModel, BookEntity>
    {
        private readonly IBookCommandRL _bookCommandRL;

        public UpdateBookCommandHandler(IBookCommandRL bookCommandRL)
        {
            _bookCommandRL = bookCommandRL;
        }

        public async Task<BookEntity> HandleAsync(int bookId, BookModel command)
        {
            try
            {
                BookEntity book = new BookEntity
                {
                    BookId = bookId,
                    Title = command.Title,
                    Author = command.Author,
                    ISBN = command.ISBN,
                    Genre = command.Genre,
                    Publisher = command.Publisher,
                    Description = command.Description,
                    Price = command.Price,
                    StockQuantity = command.StockQuantity,
                };
                return await _bookCommandRL.UpdateBookAsync(book);
            }
            catch
            {
                throw;
            }
        }
    }
}
