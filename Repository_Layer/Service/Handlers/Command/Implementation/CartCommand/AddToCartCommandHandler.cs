using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Commands.Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Implementation.CartCommand
{
    public class AddToCartCommandHandler : ICommandHandler<CartModel, CartEntity>
    {
        private readonly ICartCommandRL _cartCommandRL;

        public AddToCartCommandHandler(ICartCommandRL cartCommandRL)
        {
            _cartCommandRL = cartCommandRL;
        }

        public async Task<CartEntity> HandleAsync(CartModel cartModel)
        {
            try
            {
                return await _cartCommandRL.AddToCartAsync(cartModel);
            }
            catch
            {
                throw;
            }
        }
    }
}
