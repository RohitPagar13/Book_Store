using Business_Layer.Commands.Interface;
using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Implementation
{
    public class BookCommandBL : IBookCommandBL
    {
        private readonly ICommandHandler<BookModel, BookEntity> _addBookCommandHandler;
        private readonly ICommandHandler<int, BookEntity> _deleteBookCommandHandler;
        private readonly IUpdateCommandHandler<int, BookModel, BookEntity> _updateBookCommandHandler;

        public BookCommandBL(ICommandHandler<BookModel, BookEntity> addBookCommandHandler, ICommandHandler<int, BookEntity> deleteBookCommandHandler, IUpdateCommandHandler<int, BookModel, BookEntity> updateBookCommandHandler)
        {
            _addBookCommandHandler = addBookCommandHandler;
            _updateBookCommandHandler = updateBookCommandHandler;
            _deleteBookCommandHandler = deleteBookCommandHandler;
        }
        public async Task<BookEntity> AddBookAsync(BookModel bookModel)
        {
            try
            {
                return await _addBookCommandHandler.HandleAsync(bookModel);
            }
            catch
            {
                throw;
            }
        }

        public async Task<BookEntity> DeleteBookAsync(int bookId)
        {
            try
            {
                return await _deleteBookCommandHandler.HandleAsync(bookId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<BookEntity> UpdateBookAsync(int bookId, BookModel bookModel)
        {
            try
            {
                return await _updateBookCommandHandler.HandleAsync(bookId, bookModel);
            }
            catch
            {
                throw;
            }
        }
    }
}
