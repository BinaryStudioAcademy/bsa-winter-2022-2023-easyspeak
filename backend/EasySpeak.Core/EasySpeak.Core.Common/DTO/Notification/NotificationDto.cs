namespace EasySpeak.Core.Common.DTO.Notification
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public string SenderImagePath { get; set; } = string.Empty;
        public string SenderName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

    }
}
