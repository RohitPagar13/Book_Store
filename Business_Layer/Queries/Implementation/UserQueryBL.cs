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
        private readonly IQueryHandler<UserLoginModel, string> _loginUserQueryHandler;
        private readonly IQueryHandler<string, string> _forgotPasswordQueryHandler;

        public UserQueryBL(IQueryHandler<UserLoginModel, string> loginUserQueryHandler, IQueryHandler<string, string> forgotPasswordQueryHandler)
        {
            _loginUserQueryHandler = loginUserQueryHandler;
            _forgotPasswordQueryHandler = forgotPasswordQueryHandler;
        }

        public async Task<string> ForgetPasswordAsync(string email)
        {
            try
            {
                return await _forgotPasswordQueryHandler.HandleAsync(email);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> LoginUserAsync(UserLoginModel loginModel)
        {
            try
            {
                return await _loginUserQueryHandler.HandleAsync(loginModel);
            }
            catch
            {
                throw;
            }
        }
    }
}
