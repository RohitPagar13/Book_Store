using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Handlers.Query.Interface;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Query.Implementation.OrderQuery
{
    public class GetOrdersForUserQueryHandler : IQueryHandler<int, List<OrderEntity>>
    {
        private readonly IOrderQueryRL orderQueryRL;

        public GetOrdersForUserQueryHandler(IOrderQueryRL orderQueryRL)
        {
            this.orderQueryRL = orderQueryRL;
        }
        public async Task<List<OrderEntity>> HandleAsync(int query)
        {
            try
            {
                return await orderQueryRL.getOrdersforUser(query);
            }
            catch
            {
                throw;
            }
        }
    }
}
