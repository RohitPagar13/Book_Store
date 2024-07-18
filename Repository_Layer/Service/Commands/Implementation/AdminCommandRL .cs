using Microsoft.Data.SqlClient;
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
    public class AdminCommandRL : IAdminCommandRL
    {
        private readonly Book_Store_Context _db;
        public AdminCommandRL(Book_Store_Context db)
        {
            _db = db;
        }

        public async Task<AdminResponseModel> RegisterAdminAsync(AdminEntity admin)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (_db.Admins.Any(a => a.Email.Equals(admin.Email) || a.PhoneNo.Equals(admin.PhoneNo)))
                    {
                        throw new BookStoreException("Admin with specified Email or Phone Already Exists");
                    }
                    AdminResponseModel ur = new AdminResponseModel();

                    ur.FirstName = admin.FirstName;

                    ur.LastName = admin.LastName;

                    ur.Email = admin.Email;

                    ur.PhoneNo = admin.PhoneNo;

                    if(admin.Password != null)
                    {
                        admin.Password = HashPassword.convertToHash(admin.Password);
                    }
                    
                    ur.AdminId = admin.AdminId;

                    await _db.Admins.AddAsync(admin);
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    ur.AdminId = admin.AdminId;
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
    }
}
