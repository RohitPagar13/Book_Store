using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Queries.Query_Interface
{
    public interface IAdminQueryRL
    {
        public Task<string> LoginAdminAsync(AdminLoginModel adminLoginModel);
    }
}
