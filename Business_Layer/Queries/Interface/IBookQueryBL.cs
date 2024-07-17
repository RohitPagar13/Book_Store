using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Queries.Interface
{
    public interface IBookQueryBL
    {
        public Task<List<BookEntity>> getAllBookAsync();
        public Task<BookEntity> getBookByIdAsync(int bookId);
    }
}
