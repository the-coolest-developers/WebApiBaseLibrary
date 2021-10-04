using System;

namespace WebApiBaseLibrary.MessageQueueing.MessageQueueing
{
    public interface IMessageQueuePublisher : IDisposable
    {
        public void PublishMessage<TBody>(TBody messageBody);
    }
}