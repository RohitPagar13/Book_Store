using Repository_Layer.Entity;
using Repository_Layer.Service.Handlers.Query.Interface;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Query.Implementation.CartQuery
{
    public class GetCartsForUserQueryHandler : IQueryHandler<int, List<CartEntity>>
    {
        private readonly ICartQueryRL cartQueryRL;

        public GetCartsForUserQueryHandler(ICartQueryRL cartQueryRL)
        {
            this.cartQueryRL = cartQueryRL;
        }
        public async Task<List<CartEntity>> HandleAsync(int query)
        {
            try
            {
                return await cartQueryRL.GetAllCartsForUserAsync(query);
            }
            catch
            {
                throw;
            }
        }
    }
}
