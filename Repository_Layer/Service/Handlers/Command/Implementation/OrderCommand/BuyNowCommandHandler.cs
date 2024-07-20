using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Models;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Implementation.OrderCommand
{
    public class BuyNowCommandHandler : ICommandHandler<BuyNowModel, OrderEntity>
    {
        private readonly IOrderCommandRL _orderCommandRL;

        public BuyNowCommandHandler(IOrderCommandRL orderCommandRL)
        {
            _orderCommandRL = orderCommandRL;
        }
        public async Task<OrderEntity> HandleAsync(BuyNowModel command)
        {
            try
            {
                return await _orderCommandRL.BuyNowAsync(command);
            }
            catch
            {
                throw;
            }
        }
    }
}
