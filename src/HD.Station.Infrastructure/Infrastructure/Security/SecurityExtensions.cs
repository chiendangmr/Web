using HD.Station.Security;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HD.Station
{
    public static class SecurityExtensions
    {
        private const string GodNameIdentifier = "19f23e66-5ffa-4edc-cd88-08d453c1f162";
        //
        // Summary:
        //     Checks if a user meets a specific permission for the specified resource
        //
        // Parameters:
        //   service:
        //     The Microsoft.AspNetCore.Authorization.IAuthorizationService providing authorization.
        //
        //   user:
        //     The user to evaluate the policy against.
        //
        //   resource:
        //     The resource to evaluate the policy against.
        //
        //   permission:
        //     The permission to evaluate the policy against.
        //
        // Returns:
        //     A flag indicating whether requirement evaluation has succeeded or failed. This
        //     value is true when the user fulfills the policy, otherwise false.
        public static async Task<bool> AuthorizeAsync(this IAuthorizationService service, ClaimsPrincipal user, object resource, Permission permission = Permission.Access)
        {
            if (service == null)
            {
                return true;
            }

            if (resource == null)
            {
                return true;
            }

            return await service.AuthorizeAsync(user, resource, new PermissionAuthorizationRequirement(permission));
        }

        public static bool IsGod(this ClaimsPrincipal principal)
        {
            return principal.HasClaim(ClaimTypes.NameIdentifier, GodNameIdentifier);
        }
    }
}