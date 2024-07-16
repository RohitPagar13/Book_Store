using Microsoft.Data.SqlClient;
using Model_Layer.QueryModel;
using Model_Layer.ResponseModel;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Interface;
using RepositoryLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Implementation
{
    public class UserCommandRL : IUserCommandRL
    {
        private readonly Book_Store_Context _db;
        public UserCommandRL(Book_Store_Context db)
        {
            _db = db;
        }

        public async Task<UserResponseModel> RegisterUserAsync(User user)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (_db.Users.Any(u => u.Email.Equals(user.Email) && u.PhoneNo.Equals(user.PhoneNo)))
                    {
                        throw new BookStoreException("Customer with specified Email or Phone Already Exists");
                    }
                    UserResponseModel ur = new UserResponseModel();

                    ur.FirstName = user.FirstName;

                    ur.LastName = user.LastName;

                    ur.Email = user.Email;

                    ur.PhoneNo = user.PhoneNo;

                    ur.Role = user.Role;

                    if(user.Password != null)
                    {
                        user.Password = HashPassword.convertToHash(user.Password);
                    }
                    
                    ur.UserId = user.UserId;

                    await _db.Users.AddAsync(user);
                    await _db.SaveChangesAsync();
                    transaction.Commit();
                    ur.UserId = user.UserId;
                    return ur;
                }
                catch (SqlException se)
                {
                    transaction.Rollback();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }
    }
}
