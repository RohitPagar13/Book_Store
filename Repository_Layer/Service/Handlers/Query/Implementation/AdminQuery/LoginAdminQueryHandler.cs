using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Model_Layer.RequestModel;
using Repository_Layer.Service.Handlers.Query.Interface;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Query.Implementation.AdminQuery
{
    public class LoginAdminQueryHandler : IQueryHandler<AdminLoginModel, string>
    {
        private readonly IAdminQueryRL adminQueryRL;

        public LoginAdminQueryHandler(IAdminQueryRL adminQueryRL)
        {
            this.adminQueryRL = adminQueryRL;
        }

        public async Task<string> HandleAsync(AdminLoginModel adminLoginModel)
        {
            try
            {
                return await adminQueryRL.LoginAdminAsync(adminLoginModel);
            }
            catch
            {
                throw;
            }
        }
    }
}