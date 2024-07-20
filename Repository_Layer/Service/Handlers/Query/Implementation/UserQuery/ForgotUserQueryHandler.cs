using Model_Layer.RequestModel;
using Repository_Layer.Service.Handlers.Query.Interface;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Handlers.Query.Implementation.UserQuery
{
    public class ForgotUserQueryHandler : IQueryHandler<string, string>
    {
        private readonly IUserQueryRL userQueryRL;

        public ForgotUserQueryHandler(IUserQueryRL userQueryRL)
        {
            this.userQueryRL = userQueryRL;
        }

        public async Task<string> HandleAsync(string query)
        {
            try
            {
                return await userQueryRL.ForgetPasswordAsync(query);
            }
            catch
            {
                throw;
            }
        }
    }
}
