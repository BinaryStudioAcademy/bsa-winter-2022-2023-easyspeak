using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.RabbitMQ.Interfaces
{
    public interface IConnectionProvider
    {
        public IConnection? Connection { get; }
    }
}
