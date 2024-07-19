using Business_Layer.Commands.Interface;
using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Implementation
{
    public class WishListCommandBL : IWishListCommandBL
    {
        private readonly ICommandHandler<int, WishListEntity> _deleteFromWishListCommandHandler;
        private readonly ICommandHandler<WishListModel, WishListEntity> _addToWishListCommandHandler;

        public WishListCommandBL(ICommandHandler<int, WishListEntity> deleteFromWishListCommandHandler, ICommandHandler<WishListModel, WishListEntity> addToWishListCommandHandler)
        {
            _addToWishListCommandHandler = addToWishListCommandHandler;
            _deleteFromWishListCommandHandler = deleteFromWishListCommandHandler;
        }
        public async Task<WishListEntity> addToWishListAsync(WishListModel wishListModel)
        {
            try
            {
                return await _addToWishListCommandHandler.HandleAsync(wishListModel);
            }
            catch
            {
                throw;
            }
        }

        public async  Task<WishListEntity> removeFromWishListAsync(int wishListId)
        {
            try
            {
                return await _deleteFromWishListCommandHandler.HandleAsync(wishListId);
            }
            catch
            {
                throw;
            }
        }
    }
}
