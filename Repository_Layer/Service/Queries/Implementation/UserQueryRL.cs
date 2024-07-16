using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model_Layer.QueryModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Service.Queries.Query_Interface;
using RepositoryLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Queries.Implementation
{
    public class UserQueryRL : IUserQueryRL
    {
        private readonly Book_Store_Context _db;
        public IConfiguration _configuration;

        public UserQueryRL(Book_Store_Context db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        public Task<UserResponseModel> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginUserAsync(UserLoginModel loginModel)
        {
            try
            {
                var result = await _db.Users.Where(user => user.Email.Equals(loginModel.Email)).FirstOrDefaultAsync();
                if (result == null && loginModel.Password!=null)
                {
                    throw new BookStoreException("User not found with given Email");
                }
                else if (HashPassword.verifyHash(loginModel.Password, result.Password))
                {
                    return await JWTTokenGenerator.generateToken(result.UserId, result.Email, result.Role, _configuration);
                }
                else
                {
                    throw new BookStoreException("Please enter correct Password");
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.ToString());
                throw;
            }
        }
    }
}
