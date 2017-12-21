using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Infrastructure.Identity
{
	public class TvadPasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : User
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
			//if (hashedPassword == System.Text.Encoding.Unicode.GetString(Utility.CreateMD5(providedPassword)))
			//{
			//	return PasswordVerificationResult.Success;
			//}
			//else
			//	return PasswordVerificationResult.Failed;

			var passwordHash = HashPassword(user, providedPassword);
			if (string.Equals(hashedPassword, passwordHash))
				return PasswordVerificationResult.Success;
			else
				return PasswordVerificationResult.Failed;
		}
	}
}
