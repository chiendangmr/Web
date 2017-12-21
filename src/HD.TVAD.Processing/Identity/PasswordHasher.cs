using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Cryptography;
using System.Text;

namespace HD.TVAD.Processing.Identity
{
    public class PasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
	{
		public string HashPassword(TUser user, string password)
		{
			using (var md5 = MD5.Create())
			{
				var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
				return Convert.ToBase64String(hash);
			}
		}

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
