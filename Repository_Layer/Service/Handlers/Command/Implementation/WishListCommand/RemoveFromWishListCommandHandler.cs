using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Implementation.WishListCommand
{
    public class RemoveFromWishListCommandHandler : ICommandHandler<int, WishListEntity>
    {
        private readonly IWishListCommandRL _wishListCommandRL;

        public RemoveFromWishListCommandHandler(IWishListCommandRL wishListCommandRL)
        {
            _wishListCommandRL = wishListCommandRL;
        }
        public async Task<WishListEntity> HandleAsync(int command)
        {
            try
            {
                return await _wishListCommandRL.removeFromWishListAsync(command);
            }
            catch
            {
                throw;
            }
        }
    }
}
