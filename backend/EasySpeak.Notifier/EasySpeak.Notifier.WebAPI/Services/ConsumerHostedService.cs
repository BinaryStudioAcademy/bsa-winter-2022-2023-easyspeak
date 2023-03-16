using EasySpeak.RabbitMQ;
using EasySpeak.RabbitMQ.Interfaces;
using EasySpeak.RabbitMQ.Services;

namespace EasySpeak.Notifier.WebAPI.Services
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IMessageConsumer _consumer;
        private readonly ILogger<ConsumerHostedService> _logger;
        public ConsumerHostedService(IMessageConsumer consumer, ILogger<ConsumerHostedService> logger) 
        { 
            _consumer = consumer;
            _logger = logger;
            _consumer.Init("notifier");
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
                    _consumer.Recieve<string>((data) =>
                    {
                        Console.WriteLine(data);
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception");
                }          
            return Task.CompletedTask;
        }
    }
}
