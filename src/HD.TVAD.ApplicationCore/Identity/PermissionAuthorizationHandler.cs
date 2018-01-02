using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Security.Claims;

namespace HD.TVAD.Infrastructure.Identity
{
	public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
	{
		//public IDataContext _dbContext;
		IAuthorizationTvadService _authorizationServices;
		public PermissionAuthorizationHandler(IAuthorizationTvadService authorizationServices)
		{
			//	_dbContext = context;
			_authorizationServices = authorizationServices;
		}
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
		{
			var isSuccess = _authorizationServices.CheckPermission(context.User.Identity.Name, requirement._module, requirement._permission);
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