using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace WebApiBaseLibrary.Authorization.Extensions
{
    public static class ClaimExtensions
    {
        public static Claim GetClaim(this ClaimsPrincipal principal, string claimType)
        {
            return principal.Claims.GetClaim(claimType);
        }

        public static Claim GetClaim(this IEnumerable<Claim> claims, string claimType)
        {
            return claims.First(c => c.Type == claimType);
        }
    }
}