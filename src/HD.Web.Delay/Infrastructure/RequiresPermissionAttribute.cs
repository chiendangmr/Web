using HD.AspNetCore.Mvc.Security;
using HD.TVAD.Web.StartData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Infrastructure
{
		public class RequiresPermissionAttribute : TypeFilterAttribute
		{
			public RequiresPermissionAttribute(UserPermissions permission)
			  : base(typeof(RequiresPermissionAttributeImpl))
			{
				Arguments = new[] { new PermissionRequirement(permission) };
			}

			private class RequiresPermissionAttributeImpl : Attribute, IAsyncResourceFilter, IAuthorizationFilter
			{
				private readonly IAuthorizationService _authService;
				private readonly PermissionRequirement _requiredPermissions;

				public RequiresPermissionAttributeImpl(IAuthorizationService authService,
												PermissionRequirement requiredPermissions)
				{
					_authService = authService;
					_requiredPermissions = requiredPermissions;
				}

				public void OnAuthorization(AuthorizationFilterContext context)
				{
					var hasPermission = context.HttpContext.User.IsInRole(_requiredPermissions._permission.ToString());
					if (!hasPermission)
					{
						//	context.Result = new ForbidResult();
						context.Result = new ChallengeResult();

					}
				}

				public async Task OnResourceExecutionAsync(ResourceExecutingContext context,
														   ResourceExecutionDelegate next)
				{
					if (!await _authService.AuthorizeAsync(context.HttpContext.User,
											//	context.ActionDescriptor.ToString(),
												null,
												_requiredPermissions))
					{
						context.Result = new ChallengeResult();
					}
					else
					{
						await next();
					}
				}
			}
		}
}
