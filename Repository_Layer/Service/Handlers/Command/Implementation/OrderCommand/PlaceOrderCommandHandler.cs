using Model_Layer.RequestModel;
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
    public class PlaceOrderCommandHandler : ICommandHandler<PlaceOrderModel, OrderResponseModel>
    {
        private readonly IOrderCommandRL _orderCommandRL;

        public PlaceOrderCommandHandler(IOrderCommandRL orderCommandRL)
        {
            _orderCommandRL = orderCommandRL;
        }
        public async Task<OrderResponseModel> HandleAsync(PlaceOrderModel command)
        {
            try
            {
                return await _orderCommandRL.PlaceOrderAsync(command);
            }
            catch
            {
                throw;
            }
        }
    }
}
