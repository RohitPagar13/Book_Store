using Business_Layer.Queries.Interface;
using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Service.Handlers.Command.Interface;
using Repository_Layer.Service.Handlers.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Queries.Implementation
{
    public class UserQueryBL : IUserQueryBL
    {
        private readonly IQueryHandler<UserLoginModel, string> _registerUserQueryHandler;

        public UserQueryBL(IQueryHandler<UserLoginModel, string> registerUserQueryHandler)
        {
            _registerUserQueryHandler = registerUserQueryHandler;
        }
        public async Task<string> LoginUserAsync(UserLoginModel loginModel)
        {
            return await _registerUserQueryHandler.HandleAsync(loginModel);   
        }
    }
}
