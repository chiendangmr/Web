using HD.TVAD.Web.StartData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Infrastructure
{
	public interface IAuthorizationServices
	{
		bool CheckPermission(ClaimsPrincipal user, UserPermissions permission, object resource);
	}
}
