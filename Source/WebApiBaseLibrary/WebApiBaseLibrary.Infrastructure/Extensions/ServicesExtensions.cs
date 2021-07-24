using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiBaseLibrary.Infrastructure.Configuration;
using WebApiBaseLibrary.Infrastructure.Constants;

namespace WebApiBaseLibrary.Infrastructure.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSingletonHashConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtConfiguration = configuration.GetSection(InfrastructureAppSettings.HashConfiguration)
                .Get<HashConfiguration>();

            return services.AddSingleton(jwtConfiguration);
        }
    }
}