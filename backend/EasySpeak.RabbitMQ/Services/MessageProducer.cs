using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.RabbitMQ.Services
{
    public class MessageProducer: IMessageProducer
    {
        private readonly IConnectionProvider connectionProvider;
        private readonly IConfiguration configuration;
        private readonly IModel channel;

        public MessageProducer(IConnectionProvider connectionProvider, IConfiguration configuration)
        {
            this.connectionProvider = connectionProvider;
            this.configuration = configuration;
            channel = connectionProvider.Connection!.CreateModel();
        }
        public void SendMessage<T>(string queueKey, T message)
        {
            string queue = configuration.GetSection("RabbitQueues").GetRequiredSection(queueKey).Value;
            if (string.IsNullOrEmpty(queue))
            {
                throw new ArgumentException("Queue not found");
            }
            channel.QueueDeclare(queue, true, false, false);
            var json = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: queue, body: body);
        }
    }
}
