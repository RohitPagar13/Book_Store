using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Handlers.Query.Interface;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Query.Implementation.Book
{
    public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, List<BookEntity>>
    {
        private readonly IBookQueryRL bookQueryRL;

        public GetAllBooksQueryHandler(IBookQueryRL bookQueryRL)
        {
            this.bookQueryRL = bookQueryRL;
        }

        public async Task<List<BookEntity>> HandleAsync(GetAllBooksQuery query)
        {
            return await bookQueryRL.getAllBookAsync();
        }
    }
}
