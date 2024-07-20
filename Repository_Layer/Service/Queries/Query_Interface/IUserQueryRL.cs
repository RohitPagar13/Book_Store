using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Queries.Query_Interface
{
    public interface IUserQueryRL
    {
        public Task<string> LoginUserAsync(UserLoginModel loginModel);
        public Task<string> ForgetPasswordAsync(string email);
    }
}
