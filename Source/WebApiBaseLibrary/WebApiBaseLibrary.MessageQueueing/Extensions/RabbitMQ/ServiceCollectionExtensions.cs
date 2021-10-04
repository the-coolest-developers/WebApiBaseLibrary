using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WebApiBaseLibrary.Infrastructure.Reflection;
using WebApiBaseLibrary.MessageQueueing.Attributes;
using WebApiBaseLibrary.MessageQueueing.Configuration;
using WebApiBaseLibrary.MessageQueueing.MessageQueueing;
using WebApiBaseLibrary.MessageQueueing.MessageQueueing.RabbitMQ;

namespace WebApiBaseLibrary.MessageQueueing.Extensions.RabbitMQ
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

        public static IServiceCollection AddMessageQueueingServices(
            this IServiceCollection services,
            Assembly executingAssembly)
        {
            var messageQueueServices = ReflectionHelper
                .GetAllTypesWithAttribute<MessageQueueServiceAttribute>(executingAssembly);

            foreach (var mqService in messageQueueServices)
            {
                services.AddSingleton(mqService);
            }

            return services;
        }

        public static IServiceCollection AddMessageQueueingServices(
            this IServiceCollection services,
            Type assemblyType)
        {
            var executingAssembly = assemblyType.Assembly;

            return services.AddMessageQueueingServices(executingAssembly);
        }
    }
}