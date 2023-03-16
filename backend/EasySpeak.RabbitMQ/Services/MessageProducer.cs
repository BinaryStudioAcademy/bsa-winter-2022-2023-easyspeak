using EasySpeak.RabbitMQ.Interfaces;
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
        private readonly IModel channel;
        private string queue = string.Empty;
        private string exchange = string.Empty; 

        public MessageProducer(IConnectionProvider connectionProvider)
        {
            channel = connectionProvider.Connection!.CreateModel();
        }

        public void Init(string queue, string exchange)
        {
            this.queue = queue ?? string.Empty;
            this.exchange = exchange ?? string.Empty;
        }
        public void SendMessage<T>(T message)
        {
            channel.QueueDeclare(queue, true, false, false);
            var json = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: exchange, routingKey: queue, body: body);
        }
    }
}
