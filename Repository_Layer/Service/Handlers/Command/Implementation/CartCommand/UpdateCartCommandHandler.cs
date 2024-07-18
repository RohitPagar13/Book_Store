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
    public class UpdateCartCommandHandler : IUpdateCommandHandler<int, int, CartEntity>
    {
        private readonly ICartCommandRL _cartCommandRL;

        public UpdateCartCommandHandler(ICartCommandRL cartCommandRL)
        {
            _cartCommandRL = cartCommandRL;
        }

        public async Task<CartEntity> HandleAsync(int userId, int command)
        {
            try
            {
                return await _cartCommandRL.UpdateCartAsync(userId,command);
            }
            catch
            {
                throw;
            }
        }
    }
}
