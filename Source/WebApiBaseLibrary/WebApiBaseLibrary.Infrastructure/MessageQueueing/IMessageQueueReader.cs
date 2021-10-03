using System;

namespace WebApiBaseLibrary.Infrastructure.MessageQueueing
{
    public interface IMessageQueueReader
    {
        public void SetReceiveAction(Action<string> receivedMessageAction);
        public void StartReading();
    }
}