using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiBaseLibrary.Authorization.Constants;
using WebApiBaseLibrary.Authorization.Models;

namespace WebApiBaseLibrary.Authorization.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddSingletonJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfiguration = configuration.GetSection(Appsettings.JwtConfiguration)
                .Get<JwtConfiguration>();

            services.AddSingleton(_ => jwtConfiguration);
        }
    }
}