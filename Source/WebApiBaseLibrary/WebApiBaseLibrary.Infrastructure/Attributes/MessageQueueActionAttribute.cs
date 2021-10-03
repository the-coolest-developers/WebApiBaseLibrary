﻿using System;

namespace WebApiBaseLibrary.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MessageQueueActionAttribute : Attribute
    {
        public string QueueName { get; }

        public MessageQueueActionAttribute(string queueName)
        {
            QueueName = queueName;
        }
    }
}