using System;

namespace WebApiBaseLibrary.Infrastructure.MessageQueueing
{
    public interface IMessageQueueReader
    {
        public void SetReceivedAction(Action<string> receivedMessageAction);
        public void StartReading();
    }
}