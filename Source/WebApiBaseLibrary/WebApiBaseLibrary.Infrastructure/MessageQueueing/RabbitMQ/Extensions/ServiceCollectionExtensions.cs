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
            RabbitMQConfiguration rabbitMqConfiguration,
            Func<IServiceProvider> getServiceProvider)
        {
            services.AddSingleton<IMessageQueueConnectionFactory, RabbitMQConnectionFactory>(_ =>
            {
                var connectionFactory = new RabbitMQConnectionFactory(rabbitMqConfiguration?.HostName);

                return connectionFactory;
            });
            services.AddScoped<IMessageQueueConnection, RabbitMQConnection>(_ =>
            {
                var connectionFactory = getServiceProvider().GetService<IMessageQueueConnectionFactory>();
                var connection = connectionFactory?.CreateConnection();

                return (RabbitMQConnection) connection;
            });

            return services;
        }
    }
}