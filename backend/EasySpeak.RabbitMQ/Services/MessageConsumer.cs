using EasySpeak.RabbitMQ.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.RabbitMQ.Services
{
    public class MessageConsumer: IMessageConsumer
    {
        private readonly IModel channel;
        private EventingBasicConsumer consumer = null!;

        public MessageConsumer(IConnectionProvider connectionProvider)
        {
            channel = connectionProvider.Connection!.CreateModel();
        }

        public void Init(string queue)
        {
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
