using System;
using System.ServiceModel;
using ChatClient2.bravo_kobra;
using ChatServer2;

namespace ChatClient2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the callback using the generated interface from the service reference
            InstanceContext instanceContext = new InstanceContext(new ChatCallback());
            ChatServiceClient client = new ChatServiceClient(instanceContext);

            Console.Write("Enter your username: ");
            string user = Console.ReadLine();
            client.Connect(user);

            Console.WriteLine("You can now start chatting!");

            string message;
            while ((message = Console.ReadLine()) != "exit")
            {
                client.SendMessage(user, message);
            }

            client.Disconnect(user);
        }

        // Implement the callback interface from the generated service reference
        public class ChatCallback : IChatServiceCallback
        {
            public void ReceiveMessage(string user, string message)
            {
                Console.WriteLine($"{user}: {message}");
            }
        }
    }
}
