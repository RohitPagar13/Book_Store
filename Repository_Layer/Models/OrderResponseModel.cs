using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Models
{
    public class OrderResponseModel
    {
        public List<OrderEntity> Orders {  get; set; }

        public int DeliveryFee { get; set; } = 99;
        public double TotalPrice { get; set; }

    }
}
