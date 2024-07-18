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
    public class AdminQueryBL : IAdminQueryBL
    {
        private readonly IQueryHandler<AdminLoginModel, string> _loginAdminQueryHandler;

        public AdminQueryBL(IQueryHandler<AdminLoginModel, string> loginAdminQueryHandler)
        {
            _loginAdminQueryHandler = loginAdminQueryHandler;
        }

        public async Task<string> LoginAdminAsync(AdminLoginModel adminLoginModel)
        {
            try
            {
                return await _loginAdminQueryHandler.HandleAsync(adminLoginModel);
            }
            catch
            {
                throw;
            }
        }
    }
}
