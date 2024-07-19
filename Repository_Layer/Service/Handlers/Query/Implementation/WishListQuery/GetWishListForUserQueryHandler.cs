using Repository_Layer.Entity;
using Repository_Layer.Service.Handlers.Query.Interface;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Query.Implementation.WishListQuery
{
    public class GetWishListForUserQueryHandler : IQueryHandler<int, List<WishListEntity>>
    {
        private readonly IWishListQueryRL wishListQueryRL;

        public GetWishListForUserQueryHandler(IWishListQueryRL wishListQueryRL)
        {
            this.wishListQueryRL = wishListQueryRL;
        }
        public async Task<List<WishListEntity>> HandleAsync(int query)
        {
            try
            {
                return await wishListQueryRL.GetAllWishListForUserAsync(query);
            }
            catch
            {
                throw;
            }
        }
    }
}
