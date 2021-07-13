using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiBaseLibrary.Authorization.Configurators;
using WebApiBaseLibrary.Authorization.Constants;
using WebApiBaseLibrary.Authorization.Models;

namespace WebApiBaseLibrary.Authorization.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSingletonJwtConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtConfiguration = configuration.GetSection(Appsettings.JwtConfiguration)
                .Get<JwtConfiguration>();

            return services.AddSingleton(_ => jwtConfiguration);
        }

        public static AuthenticationBuilder AddConfiguredJwtBearer(
            this IServiceCollection services,
            IServiceProvider serviceProvider)
            => services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var jwtConfigurator = serviceProvider.GetService<IJwtConfigurator>();

                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = jwtConfigurator?.ValidationParameters;
            });
    }
}