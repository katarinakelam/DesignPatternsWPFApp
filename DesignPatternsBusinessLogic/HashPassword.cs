using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBusinessLogic
{
    public static class HashPassword
    {
      public static string GenerateSalt(int saltSize)
        {
            var random = new RNGCryptoServiceProvider();
            var buffer = new byte[saltSize];
            random.GetBytes(buffer);
            string salt = Convert.ToBase64String(buffer);

            return salt;
        }

        public static string GenerateHash(string rawPassword, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(rawPassword + salt);
            SHA256Managed hash = new SHA256Managed();
            byte[] hashPassword = hash.ComputeHash(bytes);
            string password = Convert.ToBase64String(hashPassword);

            return password;
        }
    }
}
