using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer2
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class ChatService : IChatService
    {
        private readonly Dictionary<string, IChatCallback> clients = new Dictionary<string, IChatCallback>();

        public void Connect(string user)
        {
            IChatCallback callback = OperationContext.Current.GetCallbackChannel<IChatCallback>();
            if (!clients.ContainsKey(user))
            {
                clients.Add(user, callback);
            }
        }

        public void Disconnect(string user)
        {
            if (clients.ContainsKey(user))
            {
                clients.Remove(user);
            }
        }

        public void SendMessage(string user, string message)
        {
            foreach (var callback in clients.Values)
            {
                callback.ReceiveMessage(user, message);
            }
        }
    }
}
