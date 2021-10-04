﻿using System.Diagnostics.CodeAnalysis;

namespace WebApiBaseLibrary.MessageQueueing.Constants
{
    public static class MessageQueueingAppSettings
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public const string RabbitMQConfiguration = "RabbitMQConfiguration";
    }
}