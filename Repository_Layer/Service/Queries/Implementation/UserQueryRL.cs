using Model_Layer.QueryModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Context;
using Repository_Layer.Service.Queries.Query_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Queries.Implementation
{
    public class UserQueryRL : IUserQueryRL
    {
        private readonly Book_Store_Context _db;

        public UserQueryRL(Book_Store_Context db)
        {
            _db = db;
        }
        public Task<UserResponseModel> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginUserAsync(UserLoginModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
