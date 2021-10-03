﻿using System.Diagnostics.CodeAnalysis;

namespace WebApiBaseLibrary.Infrastructure.Configuration
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class RabbitMQConfiguration
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}