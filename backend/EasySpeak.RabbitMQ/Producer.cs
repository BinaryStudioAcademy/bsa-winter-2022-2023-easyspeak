using EasySpeak.RabbitMQ.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace EasySpeak.RabbitMQ
{
    public class Producer : IMessageProducer
    {
        private readonly IConnection connection = null!;
        public Producer(string hostname)
        {
            var factory = new ConnectionFactory { Uri = new Uri(hostname) };
            connection = factory.CreateConnection();
        }
        public void SendMessage<T>(string queue, T message)
        {
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue, true, false, false);
            var json = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: queue, body: body);
        }
    }
}