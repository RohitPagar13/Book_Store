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
    public class WishListQueryBL : IWishListQueryBL
    {
        private readonly IQueryHandler<int, List<WishListEntity>> _getWishListForUserQueryHandler;

        public WishListQueryBL(IQueryHandler<int, List<WishListEntity>> getWishListForUserQueryHandler)
        {
            _getWishListForUserQueryHandler = getWishListForUserQueryHandler;
        }
        public async Task<List<WishListEntity>> GetAllWishListForUserAsync(int userId)
        {
            try
            {
                return await _getWishListForUserQueryHandler.HandleAsync(userId);
            }
            catch
            {
                throw;
            }
        }
    }
}
