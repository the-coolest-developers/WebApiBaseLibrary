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

            IMessageQueueReader leaveGameReader = connection.CreateReader("LeaveGameQueue");
            leaveGameReader.SetReceivedAction(PlayerLeft);
            leaveGameReader.StartReading();

            IMessageQueueReader joinGameReader = connection.CreateReader("JoinGameQueue");
            joinGameReader.SetReceivedAction(PlayerJoined);
            joinGameReader.StartReading();

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        static void PlayerJoined(string message)
        {
            Console.WriteLine($"Player has joined the game: {message}");
        }

        static void PlayerLeft(string message)
        {
            Console.WriteLine($"Player has left the game: {message}");
        }
    }
}