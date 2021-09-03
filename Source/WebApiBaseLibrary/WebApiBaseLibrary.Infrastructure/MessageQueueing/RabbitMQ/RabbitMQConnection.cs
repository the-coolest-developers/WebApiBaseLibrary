﻿using System;
using System.Diagnostics.CodeAnalysis;
using RabbitMQ.Client;

namespace WebApiBaseLibrary.Infrastructure.MessageQueueing.RabbitMQ
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class RabbitMQConnection : IMessageQueueConnection, IDisposable
    {
        private readonly IConnection _connection;

        public RabbitMQConnection(IConnection connection)
        {
            _connection = connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        public IMessageQueuePublisher CreatePublisher(string queueName)
        {
            var channel = _connection.CreateModel();
            var publisher = new RabbitMQPublisher(channel, queueName);

            return publisher;
        }
    }
}