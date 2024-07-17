using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Commands.Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Implementation.BookCommand
{
    public class AddBookCommandHandler : ICommandHandler<BookModel, BookEntity>
    {
        private readonly IBookCommandRL _bookCommandRL;

        public AddBookCommandHandler(IBookCommandRL bookCommandRL)
        {
            _bookCommandRL = bookCommandRL;
        }

        public async Task<BookEntity> HandleAsync(BookModel command)
        {
            try
            {
                BookEntity book = new BookEntity
                {
                    Title = command.Title,
                    Author = command.Author,
                    ISBN = command.ISBN,
                    Genre = command.Genre,
                    Publisher = command.Publisher,
                    Description = command.Description,
                    Price = command.Price,
                    StockQuantity = command.StockQuantity,
                };
                return await _bookCommandRL.AddBookAsync(book);
            }
            catch
            {
                throw;
            }
        }
    }
}
