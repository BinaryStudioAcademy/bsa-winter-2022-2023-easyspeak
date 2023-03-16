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
        private string queue = string.Empty;

        public MessageConsumer(IConnectionProvider connectionProvider)
        {
            channel = connectionProvider.Connection!.CreateModel();
        }
        public void Init(string queue)
        {
            this.queue = queue ?? string.Empty;
        }
        public void Recieve<T>(Action<T?> onMessage)
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
