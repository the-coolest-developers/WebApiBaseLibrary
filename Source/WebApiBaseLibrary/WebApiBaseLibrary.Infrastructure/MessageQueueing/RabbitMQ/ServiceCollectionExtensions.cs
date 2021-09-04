using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiBaseLibrary.Infrastructure.Configuration;
using WebApiBaseLibrary.Infrastructure.Constants;
using WebApiBaseLibrary.Infrastructure.Extensions;

namespace WebApiBaseLibrary.Infrastructure.MessageQueueing.RabbitMQ
{
    public static class ServiceCollectionExtensions
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static IServiceCollection AddRabbitMQ(
            this IServiceCollection services,
            IConfiguration configuration,
            IServiceProvider serviceProvider)
        {
            services.AddSingletonConfiguration<RabbitMQConfiguration>(
                configuration,
                InfrastructureAppSettings.RabbitMQConfiguration);

            services.AddSingleton<IMessageQueueConnectionFactory, RabbitMQConnectionFactory>(_ =>
            {
                var rabbitmqConfiguration = serviceProvider.GetService<RabbitMQConfiguration>();

                var connectionFactory = new RabbitMQConnectionFactory(rabbitmqConfiguration?.HostName);

                return connectionFactory;
            });
            services.AddScoped<IMessageQueueConnection, RabbitMQConnection>(_ =>
            {
                var connectionFactory = serviceProvider.GetService<IMessageQueueConnectionFactory>();
                var connection = connectionFactory?.GetConnection();

                return (RabbitMQConnection) connection;
            });

            return services;
        }
    }
}