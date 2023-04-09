namespace EasySpeak.Core.Common.DTO
{
    public class MessageDto
    {
        public long ChatId { get; set; }
        public long? CreatedBy { get; set; }
        public bool IsRead { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
