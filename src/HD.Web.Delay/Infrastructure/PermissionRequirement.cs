using HD.TVAD.Web.StartData;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Infrastructure
{
	public class PermissionRequirement : IAuthorizationRequirement
	{
		public UserPermissions _permission { get; private set; }

		public PermissionRequirement(UserPermissions permission)
		{
			_permission = permission;
		}

	}
}
