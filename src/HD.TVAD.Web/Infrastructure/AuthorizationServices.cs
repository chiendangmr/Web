using HD.TVAD.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HD.TVAD.Web.StartData;
using System.Security.Claims;

namespace HD.TVAD.Web.Infrastructure
{

	public class AuthorizationServices : IAuthorizationServices
	{
		private IDataContext _dbContext;
		public AuthorizationServices(IServiceProvider serviceProvider)
		{
			_dbContext = serviceProvider.GetRequiredService<HDAdDbContext>();
			//_dbContext = context;
		}

		public bool CheckPermission(ClaimsPrincipal user, UserPermissions permission, object resource)
		{
			if (resource == null && user.IsInRole(permission.ToString()))
			{
				return true;
			}
			return false;
		}
	}
}
