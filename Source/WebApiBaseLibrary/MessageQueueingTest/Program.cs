using System;
using WebApiBaseLibrary.Infrastructure.MessageQueueing;
using WebApiBaseLibrary.Infrastructure.MessageQueueing.RabbitMQ;

namespace MessageQueueingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageQueueConnectionFactory factory = new RabbitMQConnectionFactory("localhost");
            var connection = factory.CreateConnection();
            var reader = connection.CreateReader("LeaveGameQueue");

            StartReading(reader);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        static void Received(string message)
        {
            Console.WriteLine(message);
        }

        static void StartReading(IMessageQueueReader reader)
        {
            reader.SetReceivedAction(Received);
            reader.StartReading();
        }
    }
}