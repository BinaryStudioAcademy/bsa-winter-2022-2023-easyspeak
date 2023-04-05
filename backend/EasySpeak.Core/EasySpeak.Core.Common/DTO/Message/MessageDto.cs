namespace EasySpeak.Core.Common.DTO.Message
{
    public class MessageDto
    {
        public long ChatId { get; set; }
        public long? UserId { get; set; }
        public bool IsRead { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
