using EasySpeak.RabbitMQ.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EasySpeak.RabbitMQ
{
    public class Consumer : IMessageConsumer
    {
        private IModel channel = null!;
        public Consumer(string hostname) 
        {
            var factory = new ConnectionFactory { Uri = new Uri(hostname) };
            factory.AutomaticRecoveryEnabled = true;
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }
        public void Recieve<T>(string queue, Action<T?> onMessage)
        {
            channel.QueueDeclare(queue, true, false, false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var jsonSpecified = Encoding.UTF8.GetString(eventArgs.Body.Span);
                var item = JsonConvert.DeserializeObject<T>(jsonSpecified);
                onMessage(item);
            };
            channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
        }
    }
}
