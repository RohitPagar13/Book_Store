
using Repository_Layer.Service.Handlers.Query.Interface;
using Repository_Layer.Service.Queries.Implementation;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_Layer.Entity;

namespace Repository_Layer.Service.Handlers.Query.Implementation.Book
{
    public class GetBookByIdQueryHandler : IQueryHandler<int, BookEntity>
    {
        private readonly IBookQueryRL bookQueryRL;

        public GetBookByIdQueryHandler(IBookQueryRL bookQueryRL)
        {
            this.bookQueryRL = bookQueryRL;
        }

        public async Task<BookEntity> HandleAsync(int bookId)
        {
            return await bookQueryRL.getBookByIdAsync(bookId);
        }

    }
}
