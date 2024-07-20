using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Queries.Interface
{
    public interface IOrderQueryBL
    {
        public Task<List<OrderEntity>> GetAllOrdersForUserAsync(int userId);
    }
}
