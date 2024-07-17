using Repository_Layer.Custom_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Utility
{
    public static class HashPassword
    {
        public static string convertToHash(string password)
        {
            try
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
            catch
            {
                throw new BookStoreException("Unable to Encrypt Password. Please try again");
            }
        }
        public static bool verifyHash(string password, string hashPass)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashPass);
            }
            catch
            {
                throw new BookStoreException("Unable to Decrypt Password. Please try again");
            }

        }
    }
}
