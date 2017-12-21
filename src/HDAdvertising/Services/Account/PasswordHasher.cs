using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HDAdvertising.Services.Account
{
    public partial class PasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
    {
        //
        // Summary:
        //     Returns a hashed representation of the supplied password for the specified user.
        //
        // Parameters:
        //   user:
        //     The user whose password is to be hashed.
        //
        //   password:
        //     The password to hash.
        //
        // Returns:
        //     A hashed representation of the supplied password for the specified user.
        public string HashPassword(TUser user, string password)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
        //
        // Summary:
        //     Returns a Microsoft.AspNetCore.Identity.PasswordVerificationResult indicating
        //     the result of a password hash comparison.
        //
        // Parameters:
        //   user:
        //     The user whose password should be verified.
        //
        //   hashedPassword:
        //     The hash value for a user's stored password.
        //
        //   providedPassword:
        //     The password supplied for comparison.
        //
        // Returns:
        //     A Microsoft.AspNetCore.Identity.PasswordVerificationResult indicating the result
        //     of a password hash comparison.
        //
        // Remarks:
        //     Implementations of this method should be time consistent.
        public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        {
            var passwordHash = HashPassword(user, providedPassword);
            if (string.Equals(hashedPassword, passwordHash))
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }
}
