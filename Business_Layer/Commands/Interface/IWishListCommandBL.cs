using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Interface
{
    public interface IWishListCommandBL
    {
        public Task<WishListEntity> addToWishListAsync(WishListModel wishListModel);
        public Task<WishListEntity> removeFromWishListAsync(int wishListId);
    }
}
