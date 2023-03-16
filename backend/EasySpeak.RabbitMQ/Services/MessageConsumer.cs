using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;
        private readonly IModel channel;

        public MessageConsumer(IConnectionProvider connectionProvider, IConfiguration configuration)
        {
            this.connectionProvider = connectionProvider;
            this.configuration = configuration;
            channel = connectionProvider.Connection!.CreateModel();
        }
        public void Recieve<T>(string queueKey, Action<T?> onMessage)
        {
            string queue = configuration.GetSection("RabbitQueues").GetRequiredSection(queueKey).Value;
            if (string.IsNullOrEmpty(queue))
            {
                throw new ArgumentException("Queue not found");
            }
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
