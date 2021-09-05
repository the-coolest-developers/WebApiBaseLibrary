using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiBaseLibrary.Infrastructure.Configuration;
using WebApiBaseLibrary.Infrastructure.Constants;
using WebApiBaseLibrary.Infrastructure.Extensions;

namespace WebApiBaseLibrary.Infrastructure.MessageQueueing.RabbitMQ.Extensions
{
    public static class ServiceCollectionExtensions
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static IServiceCollection AddRabbitMQ(
            this IServiceCollection services,
            IConfiguration configuration,
            Func<IServiceProvider> serviceProviderFunc)
        {
            services.AddSingletonConfiguration<RabbitMQConfiguration>(
                configuration,
                InfrastructureAppSettings.RabbitMQConfiguration);

            services.AddSingleton<IMessageQueueConnectionFactory, RabbitMQConnectionFactory>(_ =>
            {
                var rabbitmqConfiguration = serviceProviderFunc().GetService<RabbitMQConfiguration>();

                var connectionFactory = new RabbitMQConnectionFactory(rabbitmqConfiguration?.HostName);

                return connectionFactory;
            });
            services.AddScoped<IMessageQueueConnection, RabbitMQConnection>(_ =>
            {
                var connectionFactory = serviceProviderFunc().GetService<IMessageQueueConnectionFactory>();
                var connection = connectionFactory?.CreateConnection();

                return (RabbitMQConnection) connection;
            });

            return services;
        }
    }
}