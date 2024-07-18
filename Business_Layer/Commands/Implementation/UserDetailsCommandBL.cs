using Business_Layer.Commands.Interface;
using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Commands.Implementation
{
    public class UserDetailsCommandBL : IUserDetailsCommandBL
    {
        private readonly ICommandHandler<UserDetailsClaimsModel, UserDetailsEntity> _addUserDetailsCommandHandler;

        public UserDetailsCommandBL(ICommandHandler<UserDetailsClaimsModel, UserDetailsEntity> addUserDetailsCommandHandler)
        {
            _addUserDetailsCommandHandler = addUserDetailsCommandHandler;
        }


        public async Task<UserDetailsEntity> addUserDetailsAsync(UserDetailsClaimsModel command)
        {
            try
            {
                return await _addUserDetailsCommandHandler.HandleAsync(command);
            }
            catch
            {
                throw;
            }
        }
    }
}
