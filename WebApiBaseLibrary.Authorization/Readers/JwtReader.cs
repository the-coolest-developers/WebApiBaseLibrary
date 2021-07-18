using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApiBaseLibrary.Authorization.Constants;
using WebApiBaseLibrary.Authorization.Extensions;

namespace WebApiBaseLibrary.Authorization.Readers
{
    public class JwtReader : IJwtReader
    {
        public string GetUserIdFromToken(string token) => GetClaimFromToken(token, WebApiClaimTypes.AccountId);
        public string GetUserRoleFromToken(string token) => GetClaimFromToken(token, ClaimTypes.Role);

        public string GetClaimFromToken(string token, string claimType)
        {
            var jwt = (JwtSecurityToken) new JwtSecurityTokenHandler().ReadToken(token);

            var result = jwt.Claims.GetClaim(claimType);
            return result.Value;
        }
    }
}