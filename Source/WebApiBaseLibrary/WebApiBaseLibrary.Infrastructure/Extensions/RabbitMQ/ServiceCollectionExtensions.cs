using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiBaseLibrary.Infrastructure.Configuration;
using WebApiBaseLibrary.Infrastructure.Constants;
using WebApiBaseLibrary.Infrastructure.MessageQueueing;
using WebApiBaseLibrary.Infrastructure.MessageQueueing.RabbitMQ;

namespace WebApiBaseLibrary.Infrastructure.Extensions.RabbitMQ
{
    public static class ServiceCollectionExtensions
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static IServiceCollection AddRabbitMQ(
            this IServiceCollection services,
            RabbitMQConfiguration rabbitMqConfiguration)
        {
            var connectionFactory = new RabbitMQConnectionFactory(rabbitMqConfiguration);
            var connection = connectionFactory.CreateConnection();
                
            services.AddSingleton<IMessageQueueConnectionFactory, RabbitMQConnectionFactory>(_ => connectionFactory);
            services.AddSingleton<IMessageQueueConnection, RabbitMQConnection>(_ => (RabbitMQConnection) connection);

            return services;
        }
    }
}