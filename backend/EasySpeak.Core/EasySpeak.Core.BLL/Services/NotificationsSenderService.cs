using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO;
using EasySpeak.RabbitMQ.Interfaces;

namespace EasySpeak.Core.BLL.Services
{
    public class NotificationsSenderService : INotificationsSenderService
    {
        private readonly IMessageProducer _messageProducer;


        public NotificationsSenderService (IFirebaseAuthService firebaseAuthService, IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;

            //string queue = $"notifications_for_{firebaseAuthService.Email}";
            //_messageProducer.Init(queue, "");

            _messageProducer.Init("notifications_for_test@test.ua", "");
        }

        public void SendNotification (NotificationDto message)
        {
            _messageProducer.SendMessage(message);
        }
    }
}
