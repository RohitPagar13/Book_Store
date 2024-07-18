using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Interface
{
    public interface IAdminCommandBL
    {
        public Task<AdminResponseModel> RegisterAdminAsync(AdminModel command);
    }
}
