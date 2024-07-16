using Model_Layer.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Queries.Interface
{
    public interface IUserQueryBL
    {
        public Task<string> LoginUserAsync(UserLoginModel loginModel);
    }
}
