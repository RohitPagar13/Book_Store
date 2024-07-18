using Business_Layer.Commands.Interface;
using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Implementation
{
    public class CartCommandBL:ICartCommandBL
    {
        private readonly ICommandHandler<int, CartEntity> _deleteCartCommandHandler;
        private readonly ICommandHandler<CartModel, CartEntity> _addCartCommandHandler;
        private readonly IUpdateCommandHandler<int, int, CartEntity> _updateCommandHandler;

        public CartCommandBL(ICommandHandler<int, CartEntity> deleteCartCommandHandler, ICommandHandler<CartModel, CartEntity> addCartCommandHandler, IUpdateCommandHandler<int, int, CartEntity> updateCommandHandler)
        {
            _deleteCartCommandHandler = deleteCartCommandHandler;
            _addCartCommandHandler = addCartCommandHandler;
            _updateCommandHandler = updateCommandHandler;
        }


        public async Task<CartEntity> DeleteCartAsync(int cartId)
        {
            try
            {
                return await _deleteCartCommandHandler.HandleAsync(cartId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CartEntity> AddToCartAsync(CartModel cartModel)
        {
            try
            {
                return await _addCartCommandHandler.HandleAsync(cartModel);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CartEntity> UpdateCartAsync(int cartId, int Quantity)
        {
            try
            {
                return await _updateCommandHandler.HandleAsync(cartId, Quantity);
            }
            catch
            {
                throw;
            }
        }
    }
}
