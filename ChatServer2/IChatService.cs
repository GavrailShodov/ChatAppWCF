using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer2
{
    [ServiceContract(CallbackContract = typeof(IChatCallback))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string user, string message);

        [OperationContract(IsOneWay = true)]
        void Connect(string user);

        [OperationContract(IsOneWay = true)]
        void Disconnect(string user);
    }

    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string user, string message);
    }
}
