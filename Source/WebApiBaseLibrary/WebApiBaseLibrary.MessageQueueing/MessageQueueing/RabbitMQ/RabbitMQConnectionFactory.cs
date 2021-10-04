using System.Diagnostics.CodeAnalysis;
using RabbitMQ.Client;
using WebApiBaseLibrary.MessageQueueing.Configuration;

namespace WebApiBaseLibrary.MessageQueueing.MessageQueueing.RabbitMQ
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class RabbitMQConnectionFactory : IMessageQueueConnectionFactory
    {
        private readonly ConnectionFactory _connectionFactory;

        public RabbitMQConnectionFactory(RabbitMQConfiguration rabbitMqConfiguration)
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = rabbitMqConfiguration.HostName,
                Port = rabbitMqConfiguration.Port,
                VirtualHost = rabbitMqConfiguration.VirtualHost,
                UserName = rabbitMqConfiguration.UserName,
                Password = rabbitMqConfiguration.Password
            };
        }

        public IMessageQueueConnection CreateConnection()
        {
            var connection = _connectionFactory.CreateConnection();

            return new RabbitMQConnection(connection);
        }
    }
}