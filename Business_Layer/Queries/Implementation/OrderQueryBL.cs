using Business_Layer.Queries.Interface;
using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Handlers.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Queries.Implementation
{
    public class OrderQueryBL:IOrderQueryBL
    {
        private readonly IQueryHandler<int, List<OrderEntity>> _getOrdersForUserQueryHandler;

        public OrderQueryBL(IQueryHandler<int, List<OrderEntity>> getOrdersForUserQueryHandler)
        {
            _getOrdersForUserQueryHandler = getOrdersForUserQueryHandler;
        }
        public async Task<List<OrderEntity>> GetAllOrdersForUserAsync(int userId)
        {
            try
            {
                return await _getOrdersForUserQueryHandler.HandleAsync(userId);
            }
            catch
            {
                throw;
            }
        }
    }
}
