using Business_Layer.Queries.Interface;
using Repository_Layer.Entity;
using Repository_Layer.Service.Handlers.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Queries.Implementation
{
    public class CartQueryBL : ICartQueryBL
    {
        private readonly IQueryHandler<int, List<CartEntity>> _getCartsForUserQueryHandler;

        public CartQueryBL(IQueryHandler<int, List<CartEntity>> getCartsForUserQueryHandler)
        {
            _getCartsForUserQueryHandler = getCartsForUserQueryHandler;
        }
        public async Task<List<CartEntity>> GetAllCartsForUserAsync(int userId)
        {
            try
            {
                return await _getCartsForUserQueryHandler.HandleAsync(userId);
            }
            catch
            {
                throw;
            }
        }
    }
}
