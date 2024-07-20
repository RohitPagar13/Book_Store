﻿using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Queries.Query_Interface
{
    public interface IOrderQueryRL
    {
        public Task<List<OrderEntity>> getOrdersforUser(int userId);
    }
}
