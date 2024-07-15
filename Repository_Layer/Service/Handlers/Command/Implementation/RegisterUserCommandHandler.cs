using Model_Layer.QueryModel;
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

namespace Repository_Layer.Service.Handlers.Command.Implementation
{
    public class RegisterUserCommandHandler : ICommandHandler<UserModel,UserResponseModel>
    {
        private readonly IUserCommandRL _userCommandRL;

        public RegisterUserCommandHandler(IUserCommandRL userCommandRL)
        {
            _userCommandRL = userCommandRL;
        }

        public async Task<UserResponseModel> HandleAsync(UserModel command)
        {
            User user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                PhoneNo = command.PhoneNo,
                Password = command.Password,
                Role = command.Role,
            };
            return await _userCommandRL.RegisterUserAsync(user);
        }
    }
}
