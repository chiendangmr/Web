using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Security
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement, IAuthorizationHandler
    {
        public PermissionAuthorizationRequirement(Permission permission)
        {
            this.Permission = permission;
        }

        public Permission Permission { get; private set; }

        public string BaseClaimType
        {
            get
            {
                return $"http://schema.hdultrasoft.com/permission#{Permission.ToString()}";
            }
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (this.Permission == Permission.Ignore || context.User.IsGod())
            {
                context.Succeed(this);
            }

            return Task.CompletedTask;
        }
    }
}