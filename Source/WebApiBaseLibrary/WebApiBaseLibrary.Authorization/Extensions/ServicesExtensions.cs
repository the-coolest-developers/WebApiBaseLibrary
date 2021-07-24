using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            var jwtConfiguration = configuration.GetSection(AuthorizationAppsettings.JwtConfiguration)
                .Get<JwtConfiguration>();

            return services.AddSingleton(_ => jwtConfiguration);
        }

        public static void AddConfiguredJwtBearer(
            this IServiceCollection services,
            Func<TokenValidationParameters> getValidationParameters)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;

                options.TokenValidationParameters = getValidationParameters();
            });
        }
    }
}