using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.Common.DTO.Notification
{
    public class NewNotificationDto
    {
        public long Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
