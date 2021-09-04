using System;

namespace WebApiBaseLibrary.Infrastructure.MessageQueueing
{
    public interface IMessageQueuePublisher : IDisposable
    {
        public void PublishMessage<TBody>(TBody messageBody);
    }
}