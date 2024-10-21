using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 2: Create a ServiceHost instance.
            ServiceHost selfHost = new ServiceHost(typeof(ChatService));
            // Step 5: Start the service.
            selfHost.Open();
            Console.WriteLine("The chat service is ready.");

            // Keep the service running until the user closes it.
            Console.WriteLine("Press <Enter> to terminate the service.");
            Console.ReadLine();
        }
    }
}
