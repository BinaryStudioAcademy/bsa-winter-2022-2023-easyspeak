using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Notifier.WebAPI.Hubs;
using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace EasySpeak.Notifier.WebAPI.Services
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IMessageConsumer _consumer;
        private readonly ILogger<ConsumerHostedService> _logger;
        private readonly NotificationHub _hub;
        public ConsumerHostedService(IMessageConsumer consumer, ILogger<ConsumerHostedService> logger, NotificationHub hub)
        {
            _consumer = consumer;
            _logger = logger;
            _hub = hub;
            _consumer.Init("notifications");
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
                _consumer.Recieve<Tuple<string, NotificationDto>>( async data =>
                {
                    if (data is not null)
                    {
                        await _hub.SendNotification(data.Item1, data.Item2);
                    }
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
