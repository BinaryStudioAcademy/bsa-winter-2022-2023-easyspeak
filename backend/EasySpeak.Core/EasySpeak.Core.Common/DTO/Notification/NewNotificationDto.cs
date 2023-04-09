using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.Common.DTO.Notification
{
    public class NewNotificationDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Text { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Link { get; set; }
        public long RelatedTo { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsRead { get; set; }

        public long? ImageId { get; set; }
    }
}
