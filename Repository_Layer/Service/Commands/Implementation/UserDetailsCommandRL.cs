using Microsoft.Data.SqlClient;
using Model_Layer.ResponseModel;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Command_Interface;
using Repository_Layer.Service.Commands.Interface;
using RepositoryLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Implementation
{
    public class UserDetailsCommandRL : IUserDetailsCommandRL
    {
        private readonly Book_Store_Context _db;
        public UserDetailsCommandRL(Book_Store_Context db)
        {
            _db = db;
        }

        public async Task<UserDetailsEntity> addUserDetailsAsync(UserDetailsEntity userDetails)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    await _db.UsersDetails.AddAsync(userDetails);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return userDetails;
                }
                catch (SqlException se)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }
    }
}
