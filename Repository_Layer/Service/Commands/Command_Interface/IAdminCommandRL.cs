using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Interface
{
    public interface IAdminCommandRL
    {
        public Task<AdminResponseModel> RegisterAdminAsync(AdminEntity admin);

    }
}
