using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model_Layer.ResponseModel;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Queries.Implementation
{
    public class OrderQueryRL : IOrderQueryRL
    {
        private readonly Book_Store_Context _db;

        public OrderQueryRL(Book_Store_Context db)
        {
            _db = db;
        }
        public async Task<List<OrderEntity>> getOrdersforUser(int userId)
        {
            try
            {
                var userOrders = await _db.Orders.Where(o => o.UserDetails.UserEntityId == userId).ToListAsync();

                if (userOrders != null)
                {
                    return userOrders;
                }
                throw new BookStoreException("Previous Orders not found");
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.ToString());
                throw;
            }
        }
    }
}
