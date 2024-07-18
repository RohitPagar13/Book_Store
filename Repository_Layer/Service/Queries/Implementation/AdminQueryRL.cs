using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model_Layer.RequestModel;
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
    public class AdminQueryRL : IAdminQueryRL
    {
        private readonly Book_Store_Context _db;
        public IConfiguration _configuration;

        public AdminQueryRL(Book_Store_Context db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public async Task<string> LoginAdminAsync(AdminLoginModel adminLoginModel)
        {
            try
            {
                var result = await _db.Admins.Where(user => user.Email.Equals(adminLoginModel.Email)).FirstOrDefaultAsync();
                if (result == null && adminLoginModel.Password!=null)
                {
                    throw new BookStoreException("Admin not found with given Email");
                }
                else if (HashPassword.verifyHash(adminLoginModel.Password, result.Password))
                {
                    var token = await JWTTokenGenerator.generateToken(result.AdminId, result.Email, "Admin", _configuration);
                    return token;
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
