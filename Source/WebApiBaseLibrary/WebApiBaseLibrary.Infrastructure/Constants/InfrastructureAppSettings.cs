using System.Diagnostics.CodeAnalysis;

namespace WebApiBaseLibrary.Infrastructure.Constants
{
    public static class InfrastructureAppSettings
    {
        public const string HashConfiguration = "HashConfiguration";

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public const string RabbitMQConfiguration = "RabbitMQConfiguration";
    }
}