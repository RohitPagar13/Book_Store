using Model_Layer.RequestModel;
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
        public Task<OrderResponseModel> PlaceOrderAnync(int userId, int userDetailsId);
    }
}
