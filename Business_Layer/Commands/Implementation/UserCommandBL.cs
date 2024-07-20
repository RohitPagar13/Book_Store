using Business_Layer.Commands.Interface;
using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Implementation;
using Repository_Layer.Service.Commands.Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Implementation
{
    public class UserCommandBL : IUserCommandBL
    {
        private readonly ICommandHandler<UserModel,UserResponseModel> _registerUserCommandHandler;
        private readonly IUpdateCommandHandler<string, string, string> _resetPasswordCommandHandler;

        public UserCommandBL(ICommandHandler<UserModel,UserResponseModel> registerUserCommandHandler, IUpdateCommandHandler<string, string, string> resetPasswordCommandHandler)
        {
            _registerUserCommandHandler = registerUserCommandHandler;
            _resetPasswordCommandHandler = resetPasswordCommandHandler;
        }

        public async Task<UserResponseModel> RegisterUserAsync(UserModel command)
        {
            try
            {
                return await _registerUserCommandHandler.HandleAsync(command);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> ResetPasswordAsync(string email, string password)
        {
            try
            {
                return await _resetPasswordCommandHandler.HandleAsync(email, password);
            }
            catch
            {
                throw;
            }
        }
    }
}
