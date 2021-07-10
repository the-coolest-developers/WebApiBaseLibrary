using System.Collections.Generic;
using System.Security.Claims;

namespace WebApiBaseLibrary.Authorization.Generators
{
    public interface IJwtGenerator
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}