namespace WebApiBaseLibrary.Infrastructure.MessageQueueing
{
    public interface IMessageQueueConnectionFactory
    {
        public IMessageQueueConnection CreateConnection();
    }
}