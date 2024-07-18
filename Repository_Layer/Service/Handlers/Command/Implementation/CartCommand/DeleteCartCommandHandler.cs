using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Implementation.CartCommand
{
    public class DeleteCartCommandHandler : ICommandHandler<int,CartEntity>
    {
        private readonly ICartCommandRL _cartCommandRL;

        public DeleteCartCommandHandler(ICartCommandRL cartCommandRL)
        {
            _cartCommandRL = cartCommandRL;
        }

        public async Task<CartEntity> HandleAsync(int command)
        {
            try
            {
                return await _cartCommandRL.DeleteCartAsync(command);
            }
            catch
            {
                throw;
            }
        }
    }
}
