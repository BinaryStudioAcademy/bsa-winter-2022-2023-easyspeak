using EasySpeak.RabbitMQ.Interfaces;
using EasySpeak.RabbitMQ;
using EasySpeak.RabbitMQ.Services;

namespace EasySpeak.Notifier.WebAPI.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            var hostname = configuration.GetValue<string>("Rabbit");
            services.AddSingleton<IConnectionProvider>(_ => new ConnectionProvider(hostname));
            services.AddTransient<IMessageConsumer, MessageConsumer>();
        }
    }
}
