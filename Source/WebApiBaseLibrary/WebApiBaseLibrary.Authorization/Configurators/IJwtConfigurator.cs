using Microsoft.IdentityModel.Tokens;
using WebApiBaseLibrary.Authorization.Models;

namespace WebApiBaseLibrary.Authorization.Configurators
{
    public interface IJwtConfigurator
    {
        JwtConfiguration Configuration { get; }
        TokenValidationParameters ValidationParameters { get; }
        SigningCredentials GetSigningCredentials();
    }
}