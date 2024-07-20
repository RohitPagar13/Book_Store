using Business_Layer.Commands.Interface;
using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Models;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Implementation
{
    public class OrderCommandBL : IOrderCommandBL
    {
        private readonly ICommandHandler<PlaceOrderModel, OrderResponseModel> _placeOrderCommandHandler;
        private readonly ICommandHandler<int, OrderEntity> _cancelOrderCommandHandler;
        private readonly ICommandHandler<BuyNowModel, OrderEntity> _buyNowCommandHandler;

        public OrderCommandBL (ICommandHandler<PlaceOrderModel, OrderResponseModel> placeOrderCommandHandler, ICommandHandler<int, OrderEntity> cancelOrderCommandHandler, ICommandHandler<BuyNowModel, OrderEntity> buyNowCommandHandler)
        {
            _placeOrderCommandHandler = placeOrderCommandHandler;
            _cancelOrderCommandHandler = cancelOrderCommandHandler;
            _buyNowCommandHandler = buyNowCommandHandler;
        }
        public async Task<OrderEntity> BuyNowAsync(BuyNowModel buyNowModel)
        {
            try
            {
                return await _buyNowCommandHandler.HandleAsync(buyNowModel);
            }
            catch
            {
                throw;
            }
        }

        public async Task<OrderEntity> CancelOrderAsync(int orderId)
        {
            try
            {
                return await _cancelOrderCommandHandler.HandleAsync(orderId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<OrderResponseModel> PlaceOrderAsync(PlaceOrderModel orderModel)
        {
            try
            {
                return await _placeOrderCommandHandler.HandleAsync(orderModel);
            }
            catch
            {
                throw;
            }
        }
    }
}
