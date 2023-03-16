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
        private readonly IConnectionProvider connectionProvider;

        public MessageConsumer(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }
        public void Recieve<T>(string queue, Action<T?> onMessage)
        {
            var channel = connectionProvider.Connection?.CreateModel();
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
