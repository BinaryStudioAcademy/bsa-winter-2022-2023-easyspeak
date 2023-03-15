using EasySpeak.RabbitMQ;
using EasySpeak.RabbitMQ.Interfaces;

namespace EasySpeak.Notifier.WebAPI.Services
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IMessageConsumer _consumer;
        public ConsumerHostedService(IMessageConsumer consumer) 
        { 
            _consumer = consumer;
        }

        public override void Dispose()
        {
            base.Dispose();
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
                    //var hubContext = (IHubContext) app.ApplicationServices.GetService<IHubContext>()!;
                    _consumer.Recieve<string>("notifier", (data) =>
                    {
                        Console.WriteLine(data);
                        //await hubContext.Clients.All.SendAsync("user", data);
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
