using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Model_Layer.RequestModel;
using Repository_Layer.Service.Handlers.Query.Interface;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Query.Implementation.UserQuery
{
    public class LoginUserQueryHandler : IQueryHandler<UserLoginModel, string>
    {
        private readonly IUserQueryRL userQueryRL;

        public LoginUserQueryHandler(IUserQueryRL userQueryRL)
        {
            this.userQueryRL = userQueryRL;
        }

        public async Task<string> HandleAsync(UserLoginModel userLoginModel)
        {
            try
            {
                return await userQueryRL.LoginUserAsync(userLoginModel);
            }
            catch
            {
                throw;
            }
        }
    }
}