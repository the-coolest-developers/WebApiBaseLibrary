using System.Diagnostics.CodeAnalysis;
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
            => services.AddSingletonConfiguration<HashConfiguration>(configuration,
                InfrastructureAppSettings.HashConfiguration);

        public static IServiceCollection AddSingletonConfiguration<TConfiguration>(
            this IServiceCollection services,
            IConfiguration configuration,
            string configurationSectionName)
            where TConfiguration : class
        {
            var jwtConfiguration = configuration
                .GetSection(configurationSectionName)
                .Get<TConfiguration>();

            return services.AddSingleton(jwtConfiguration);
        }
    }
}