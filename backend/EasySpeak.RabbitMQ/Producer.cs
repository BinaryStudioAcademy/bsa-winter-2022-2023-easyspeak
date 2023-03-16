using EasySpeak.RabbitMQ.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace EasySpeak.RabbitMQ
{
    public class Producer : IMessageProducer
    {
        private readonly string _queue;
        private readonly IModel channel = null!;
        public Producer(string hostname, string queue)
        {
            _queue = queue;
            var factory = new ConnectionFactory { Uri = new Uri(hostname) };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue, true, false, false);
        }
        public void SendMessage<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: _queue, body: body);
        }
    }
}