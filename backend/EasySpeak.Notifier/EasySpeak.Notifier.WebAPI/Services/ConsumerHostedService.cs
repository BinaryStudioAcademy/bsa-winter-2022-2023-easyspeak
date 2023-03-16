using EasySpeak.RabbitMQ;
using EasySpeak.RabbitMQ.Interfaces;
using EasySpeak.RabbitMQ.Services;

namespace EasySpeak.Notifier.WebAPI.Services
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IMessageConsumer _consumer;
        public ConsumerHostedService(IMessageConsumer consumer) 
        { 
            _consumer = consumer;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
                {
                    _consumer.Init("notifier");
                    _consumer.Recieve<string>((data) =>
                    {
                        Console.WriteLine(data);
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }          
            return Task.CompletedTask;
        }
    }
}
