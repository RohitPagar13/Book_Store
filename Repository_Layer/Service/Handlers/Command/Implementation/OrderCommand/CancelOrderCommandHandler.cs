using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Implementation.OrderCommand
{
    public class CancelOrderCommandHandler : ICommandHandler<int, OrderEntity>
    {
        private readonly IOrderCommandRL _orderCommandRL;

        public CancelOrderCommandHandler(IOrderCommandRL orderCommandRL)
        {
            _orderCommandRL = orderCommandRL;
        }
        public async Task<OrderEntity> HandleAsync(int command)
        {
            try
            {
                return await _orderCommandRL.CancelOrderAsync(command);
            }
            catch
            {
                throw;
            }
        }
    }
}
