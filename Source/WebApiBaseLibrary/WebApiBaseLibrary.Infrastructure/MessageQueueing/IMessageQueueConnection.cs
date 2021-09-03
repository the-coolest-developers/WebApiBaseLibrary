﻿using System;

namespace WebApiBaseLibrary.Infrastructure.MessageQueueing
{
    public interface IMessageQueueConnection : IDisposable
    {
        public IMessageQueuePublisher CreatePublisher(string queueName);
    }
}