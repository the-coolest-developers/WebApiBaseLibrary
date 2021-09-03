using System.Diagnostics.CodeAnalysis;

namespace WebApiBaseLibrary.Infrastructure.Configuration
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class RabbitMQConfiguration
    {
        public string HostName { get; set; }
    }
}