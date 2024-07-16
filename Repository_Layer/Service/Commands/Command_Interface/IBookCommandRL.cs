using Model_Layer.QueryModel;
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
        public BookEntity AddBookAsync(BookModel bookModel);
    }
}
