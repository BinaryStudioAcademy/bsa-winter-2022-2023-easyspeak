namespace EasySpeak.Core.Common.DTO
{
    public class NewMessageDto
    {
        public long ChatId { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
    }
}
