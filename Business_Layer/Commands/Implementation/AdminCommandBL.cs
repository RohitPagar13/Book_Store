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
    public class AdminCommandBL : IAdminCommandBL
    {
        private readonly ICommandHandler<AdminModel,AdminResponseModel> _registerAdminCommandHandler;

        public AdminCommandBL(ICommandHandler<AdminModel,AdminResponseModel> registerAdminCommandHandler)
        {
            _registerAdminCommandHandler = registerAdminCommandHandler;
        }

        public async Task<AdminResponseModel> RegisterAdminAsync(AdminModel command)
        {
            try
            {
                return await _registerAdminCommandHandler.HandleAsync(command);
            }
            catch
            {
                throw;
            }
        }
    }
}
