using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using WebApiBaseLibrary.Infrastructure.Reflection;
using WebApiBaseLibrary.MessageQueueing.Attributes;
using WebApiBaseLibrary.MessageQueueing.MessageQueueing;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiBaseLibrary.MessageQueueing.Extensions.RabbitMQ
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMessageQueueingServices(
            this IApplicationBuilder app,
            Assembly executingAssembly)
        {
            var messageQueueServices = ReflectionHelper
                .GetAllTypesWithAttribute<MessageQueueServiceAttribute>(executingAssembly)
                .ToArray();

            var connection = app.ApplicationServices.GetService<IMessageQueueConnection>();

            foreach (var messageQueueServiceType in messageQueueServices)
            {
                var methodsWithAttribute = messageQueueServiceType
                    .GetMethods()
                    .Where(m => m.GetCustomAttributes<MessageQueueActionAttribute>().Any());

                var messageQueueServiceActionMethods = methodsWithAttribute
                    .ToDictionary(
                        m => m.GetCustomAttribute<MessageQueueActionAttribute>()?.QueueName,
                        m => m);

                foreach (var (queueName, method) in messageQueueServiceActionMethods)
                {
                    var reader = connection?.CreateReader(queueName);

                    var parameter = method.GetParameters().FirstOrDefault();
                    var parameterType = parameter?.ParameterType;

                    reader?.SetReceiveAction(message =>
                    {
                        var serviceInstance = app.ApplicationServices.GetService(messageQueueServiceType);

                        var deserializedMessage = JsonConvert.DeserializeObject(message, parameterType!);

                        method.Invoke(serviceInstance, new[] {deserializedMessage});
                    });
                    reader?.StartReading();
                }
            }

            return app;
        }

        public static IApplicationBuilder UseMessageQueueingServices(
            this IApplicationBuilder app,
            Type assemblyType)
        {
            var executingAssembly = assemblyType.Assembly;

            return app.UseMessageQueueingServices(executingAssembly);
        }
    }
}