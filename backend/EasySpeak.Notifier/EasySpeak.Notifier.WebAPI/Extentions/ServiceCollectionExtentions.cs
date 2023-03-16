using EasySpeak.RabbitMQ.Interfaces;
using EasySpeak.RabbitMQ;

namespace EasySpeak.Notifier.WebAPI.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            var hostname = configuration.GetValue<string>("Rabbit");
            services.AddSingleton<IMessageConsumer>(_ => new Consumer(hostname, "notifier"));
        }
    }
}
