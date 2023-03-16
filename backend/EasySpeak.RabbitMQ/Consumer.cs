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
    public class Consumer : IMessageConsumer
    {
        private EventingBasicConsumer consumer = null!;
        public Consumer(string hostname, string queue) 
        {
            var factory = new ConnectionFactory { Uri = new Uri(hostname) };
            factory.AutomaticRecoveryEnabled = true;
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue, true, false, false);
            consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
        }
        public void Recieve<T>(Action<T?> onMessage)
        {         
            consumer.Received += (model, eventArgs) =>
            {
                var jsonSpecified = Encoding.UTF8.GetString(eventArgs.Body.Span);
                var item = JsonConvert.DeserializeObject<T>(jsonSpecified);
                onMessage(item);
            };
           
        }
    }
}
