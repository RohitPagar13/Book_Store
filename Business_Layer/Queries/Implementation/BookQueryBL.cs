using Business_Layer.Queries.Interface;
using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Handlers.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Queries.Implementation
{
    public class BookQueryBL : IBookQueryBL
    {
        private readonly IQueryHandler<int,BookEntity> _getBookByIdQueryHandler;
        private readonly IQueryHandler<GetAllBooksQuery, List<BookEntity>> _getAllBooksQueryHandler;

        public BookQueryBL(IQueryHandler<int, BookEntity> getBookByIdQueryHandler, IQueryHandler<GetAllBooksQuery, List<BookEntity>> getAllBooksQueryHandler)
        {
            _getBookByIdQueryHandler = getBookByIdQueryHandler;
            _getAllBooksQueryHandler = getAllBooksQueryHandler;
        }
        public async Task<List<BookEntity>> getAllBookAsync(GetAllBooksQuery getAllBooksQuery)
        {
            try
            {
                return await _getAllBooksQueryHandler.HandleAsync(getAllBooksQuery);
            }
            catch
            {
                throw;
            }
        }

        public async Task<BookEntity> getBookByIdAsync(int bookId)
        {
            return await _getBookByIdQueryHandler.HandleAsync(bookId);
        }
    }
}
