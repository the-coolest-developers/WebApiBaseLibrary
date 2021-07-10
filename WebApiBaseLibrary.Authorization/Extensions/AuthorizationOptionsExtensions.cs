using Microsoft.AspNetCore.Authorization;
using WebApiBaseLibrary.Authorization.Constants;
using WebApiBaseLibrary.Authorization.Enums;

namespace WebApiBaseLibrary.Authorization.Extensions
{
    public static class AuthorizationOptionsExtensions
    {
        public static void AddRequireAdministratorRolePolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(AuthorizationPolicies.RequireAdministratorRole,
                policy => policy.RequireUserRole(UserRole.Admin));
        }
    }
}