using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.RabbitMQ.Interfaces
{
    public interface IMessageProducer
    {
        void Init(string queue, string exchange);
        void SendMessage<T>(T message);
    }
}
