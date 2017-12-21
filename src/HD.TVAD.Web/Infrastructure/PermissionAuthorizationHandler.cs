using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Infrastructure
{
	public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
	{
		private readonly IAuthorizationServices _authorizationServices;
		public PermissionAuthorizationHandler(IAuthorizationServices authorizationServices)
		{
			_authorizationServices = authorizationServices;
		}
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
		{
			var isSuccess = _authorizationServices.CheckPermission(context.User, requirement._permission, context.Resource);
			if (isSuccess)
			{
				context.Succeed(requirement);
			}
			else
			{
				context.Fail();
			}
			return Task.CompletedTask;
		}
	}
}
