using System.Diagnostics.CodeAnalysis;
using RabbitMQ.Client;

namespace WebApiBaseLibrary.Infrastructure.MessageQueueing.RabbitMQ
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class RabbitMQConnectionFactory : IMessageQueueConnectionFactory
    {
        private readonly ConnectionFactory _connectionFactory;

        public RabbitMQConnectionFactory(string hostName)
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = hostName
            };
        }

        public IMessageQueueConnection CreateConnection()
        {
            var connection = _connectionFactory.CreateConnection();

            return new RabbitMQConnection(connection);
        }
    }
}