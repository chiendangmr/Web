using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Infrastructure.Identity
{
	public class PermissionRequirement : IAuthorizationRequirement
	{
		public ModuleType _module { get; private set; }
		public PermissionActionType _permission { get; private set; }

		public PermissionRequirement(ModuleType module, PermissionActionType permission)
		{
			_module = module;
			_permission = permission;
		}
	}
}
