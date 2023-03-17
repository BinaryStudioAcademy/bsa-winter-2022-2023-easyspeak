using EasySpeak.RabbitMQ.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EasySpeak.RabbitMQ
{
    public class ConnectionProvider : IConnectionProvider
    {
        public  IConnection Connection { get; }

        public ConnectionProvider(string hostname) 
        {
            var factory = new ConnectionFactory { Uri = new Uri(hostname) };
            factory.AutomaticRecoveryEnabled = true;
            Connection = factory.CreateConnection();
        }
        
    }
}
