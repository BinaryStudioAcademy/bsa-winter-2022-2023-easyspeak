using EasySpeak.RabbitMQ.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace EasySpeak.RabbitMQ
{
    public class Producer : IMessageProducer
    {
        private readonly string _hostname;
        public Producer(string hostname)
        {
            _hostname = hostname;
        }
        public async Task SendMessageAsync<T>(string queue,T message)
        {
            await Task.Run(() =>
            {
                var factory = new ConnectionFactory { Uri = new Uri(_hostname) };
                var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.QueueDeclare(queue, true, false, false);

                var json = JsonConvert.SerializeObject(message);

                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "", routingKey: queue, body: body);
            });
        }
    }
}