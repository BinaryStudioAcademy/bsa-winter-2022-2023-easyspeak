using EasySpeak.RabbitMQ;
using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace EasySpeak.Notifier.WebAPI.Extentions
{
    public static class ApplicationBuilderExtentions
    {
        public static void SubscribeOnMessageRecieving(this IApplicationBuilder app)
        {
            var consumer = (IMessageConsumer) app.ApplicationServices.GetService<IMessageConsumer>()!;
            //var hubContext = (IHubContext) app.ApplicationServices.GetService<IHubContext>()!;
            consumer.Recieve<string>("notifier", (data) =>
            {
                Console.WriteLine(data);
                //await hubContext.Clients.All.SendAsync("user", data);
            });
        }

    }
}
