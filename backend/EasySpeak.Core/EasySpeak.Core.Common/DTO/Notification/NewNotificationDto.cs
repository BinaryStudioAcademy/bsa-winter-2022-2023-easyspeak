using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.Common.DTO.Notification
{
    public class NewNotificationDto
    {
        public string Text { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        
        public string? Link { get; set; }
        public long RelatedTo { get; set; }
    }
}
