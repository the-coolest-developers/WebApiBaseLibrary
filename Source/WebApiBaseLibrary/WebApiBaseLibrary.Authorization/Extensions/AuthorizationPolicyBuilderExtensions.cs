using System.Linq;
using Microsoft.AspNetCore.Authorization;
using WebApiBaseLibrary.Authorization.Enums;

namespace WebApiBaseLibrary.Authorization.Extensions
{
    public static class AuthorizationPolicyBuilderExtensions
    {
        public static void RequireUserRole(
            this AuthorizationPolicyBuilder policyBuilder,
            params UserRole[] userRoles)
        {
            var roles = userRoles.Select(role => role.ToString());
            policyBuilder.RequireRole(roles);
        }
    }
}