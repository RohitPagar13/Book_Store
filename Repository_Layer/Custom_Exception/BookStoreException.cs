using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Custom_Exception
{
    public class BookStoreException:ApplicationException
    {
        public BookStoreException(string message):base(message)
        {
        }
    }
}
