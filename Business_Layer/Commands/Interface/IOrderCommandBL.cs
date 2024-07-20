using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Interface
{
    public interface IOrderCommandBL
    {
        public Task<OrderResponseModel> PlaceOrderAsync(PlaceOrderModel orderModel);
        public Task<OrderEntity> CancelOrderAsync(int orderId);
        public Task<OrderEntity> BuyNowAsync(BuyNowModel buyNowModel);
    }
}
