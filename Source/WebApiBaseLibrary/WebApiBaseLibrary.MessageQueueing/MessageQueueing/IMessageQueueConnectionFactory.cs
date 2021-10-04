namespace WebApiBaseLibrary.MessageQueueing.MessageQueueing
{
    public interface IMessageQueueConnectionFactory
    {
        public IMessageQueueConnection CreateConnection();
    }
}