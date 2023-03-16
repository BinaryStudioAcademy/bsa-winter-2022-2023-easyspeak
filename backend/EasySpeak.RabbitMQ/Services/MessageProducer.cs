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
        private readonly IConnectionProvider connectionProvider;

        public MessageProducer(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }
        public void SendMessage<T>(string queue, T message)
        {
            var channel = connectionProvider.Connection?.CreateModel();
            channel.QueueDeclare(queue, true, false, false);
            var json = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: queue, body: body);
        }
    }
}
