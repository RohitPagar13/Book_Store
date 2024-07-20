using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model_Layer.ResponseModel;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using Repository_Layer.Service.Commands.Interface;
using RepositoryLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Service.Commands.Implementation
{
    public class UserCommandRL : IUserCommandRL
    {
        private readonly Book_Store_Context _db;
        public readonly IConfiguration _configuration;
        public UserCommandRL(Book_Store_Context db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public async Task<UserResponseModel> RegisterUserAsync(UserEntity user)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (_db.Users.Any(u => u.Email.Equals(user.Email) || u.PhoneNo.Equals(user.PhoneNo)))
                    {
                        throw new BookStoreException("Customer with specified Email or Phone Already Exists");
                    }
                    UserResponseModel ur = new UserResponseModel();

                    ur.FirstName = user.FirstName;

                    ur.LastName = user.LastName;

                    ur.Email = user.Email;

                    ur.PhoneNo = user.PhoneNo;

                    if(user.Password != null)
                    {
                        user.Password = HashPassword.convertToHash(user.Password);
                    }
                    
                    ur.UserId = user.UserId;

                    await _db.Users.AddAsync(user);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    ur.UserId = user.UserId;
                    return ur;
                }
                catch (SqlException se)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine(se.ToString());
                    throw;
                }
            }
        }

        public async Task<string> ResetPasswordAsync(string email, string password)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var user = await _db.Users.FirstOrDefaultAsync(s => s.Email == email);
                    if (user == null)
                    {
                        throw new BookStoreException("Invalid Credentials");
                    }

                    user.Password = HashPassword.convertToHash(password);

                    _db.Users.Update(user);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return email;
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
