﻿using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Notifier.WebAPI.Hubs;
using EasySpeak.RabbitMQ;
using EasySpeak.RabbitMQ.Interfaces;
using EasySpeak.RabbitMQ.Services;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace EasySpeak.Notifier.WebAPI.Services
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IMessageConsumer _consumer;
        private readonly ILogger<ConsumerHostedService> _logger;
        private readonly IHubContext<NotificationHub> _hubContext;
        public ConsumerHostedService(IMessageConsumer consumer, ILogger<ConsumerHostedService> logger, IHubContext<NotificationHub> hubContext) 
        { 
            _consumer = consumer;
            _logger = logger;
            _hubContext = hubContext;
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
                    _consumer.Recieve<NewNotificationDto>((data) =>
                    {
                        _hubContext.Clients.All.SendAsync("Notification", JsonConvert.SerializeObject(data));
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
