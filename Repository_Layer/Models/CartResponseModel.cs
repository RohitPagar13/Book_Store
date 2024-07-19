using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer.ResponseModel
{
    public class CartResponseModel
    {
        public List<CartEntity>? AllCartsforUser {  get; set; }

        public double TotalCartPrice {  get; set; }
        public double deliveryFee { get; set; } = 99;

        public double TotalPrice { get; set; }
    }
}
