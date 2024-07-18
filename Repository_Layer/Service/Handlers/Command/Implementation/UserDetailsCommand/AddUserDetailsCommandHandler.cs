using Model_Layer.RequestModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Commands.Interface;
using Repository_Layer.Service.Handlers.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Command.Implementation.UserDetailsCommand
{
    public class AddUserDetailsCommandHandler : ICommandHandler<UserDetailsClaimsModel, UserDetailsEntity>
    {
        private readonly IUserDetailsCommandRL _userDetailsCommandRL;

        public AddUserDetailsCommandHandler(IUserDetailsCommandRL userDetailsCommandRL)
        {
            _userDetailsCommandRL = userDetailsCommandRL;
        }

        public async Task<UserDetailsEntity> HandleAsync(UserDetailsClaimsModel command)
        {
            try
            {
                UserDetailsEntity user = new UserDetailsEntity
                {
                    AddressType =command.AddressType,
                    AddressLine = command.AddressLine,
                    LandMark = command.LandMark,
                    City = command.City,
                    Country = command.Country,
                    ZipCode = command.ZipCode,
                    UserId = command.UserId,
                };
                return await _userDetailsCommandRL.addUserDetailsAsync(user);
            }
            catch
            {
                throw;
            }
        }
    }
}
