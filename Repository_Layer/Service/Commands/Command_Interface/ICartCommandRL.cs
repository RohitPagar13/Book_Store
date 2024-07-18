using Model_Layer.RequestModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Command_Interface
{
    public interface ICartCommandRL
    {
        public Task<CartEntity> AddToCartAsync(CartModel cartModel);
        public Task<CartEntity> UpdateCartAsync(int cartId, int Quantity);
        public Task<CartEntity> DeleteCartAsync(int cartId);

    }
}
