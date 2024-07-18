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

namespace Repository_Layer.Service.Handlers.Command.Implementation.AdminCommand
{
    public class RegisterAdminCommandHandler : ICommandHandler<AdminModel, AdminResponseModel>
    {
        private readonly IAdminCommandRL _adminCommandRL;

        public RegisterAdminCommandHandler(IAdminCommandRL adminCommandRL)
        {
            _adminCommandRL = adminCommandRL;
        }

        public async Task<AdminResponseModel> HandleAsync(AdminModel command)
        {
            try
            {
                AdminEntity admin = new AdminEntity
                {
                    FirstName = command.FirstName?.ToLower(),
                    LastName = command.LastName?.ToLower(),
                    Email = command.Email?.ToLower(),
                    PhoneNo = command.PhoneNo,
                    Password = command.Password,
                };
                return await _adminCommandRL.RegisterAdminAsync(admin);
            }
            catch
            {
                throw;
            }
        }
    }
}
