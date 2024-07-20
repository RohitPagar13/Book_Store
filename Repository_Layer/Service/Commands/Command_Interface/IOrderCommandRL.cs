﻿using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using Repository_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Command_Interface
{
    public interface IOrderCommandRL
    {
        public Task<OrderResponseModel> PlaceOrderAsync(PlaceOrderModel orderModel);
        public Task<OrderEntity> CancelOrderAsync(int orderId);
        public Task<OrderEntity> BuyNowAsync(BuyNowModel buyNowModel);
    }
}