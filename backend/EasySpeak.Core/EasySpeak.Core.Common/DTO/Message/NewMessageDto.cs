namespace EasySpeak.Core.Common.DTO
{
    public class NewMessageDto
    {
        public long ChatId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
