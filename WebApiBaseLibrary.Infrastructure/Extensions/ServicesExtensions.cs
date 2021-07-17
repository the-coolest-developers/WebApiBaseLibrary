using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiBaseLibrary.Authorization.Constants;
using WebApiBaseLibrary.Infrastructure.Configuration;

namespace WebApiBaseLibrary.Infrastructure.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSingletonHashConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtConfiguration = configuration.GetSection(Appsettings.HashConfiguration)
                .Get<HashConfiguration>();

            return services.AddSingleton(_ => jwtConfiguration);
        }
    }
}