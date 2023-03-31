using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.Common.DTO.Notification
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Link { get; set; }
        public long RelatedTo { get; set; }
        public bool IsRead { get; set; }

    }
}
