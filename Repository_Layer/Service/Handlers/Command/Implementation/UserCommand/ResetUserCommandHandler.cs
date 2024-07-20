using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Implementation.UserCommand
{
    public class ResetUserCommandHandler: IUpdateCommandHandler<string, string,string>
    {
        private readonly IUserCommandRL _userCommandRL;

        public ResetUserCommandHandler(IUserCommandRL userCommandRL)
        {
            _userCommandRL = userCommandRL;
        }

        public async Task<string> HandleAsync(string command1, string command2)
        {
            try
            {
                return await _userCommandRL.ResetPasswordAsync(command1,command2);
            }
            catch
            {
                throw;
            }
        }
    }
}
