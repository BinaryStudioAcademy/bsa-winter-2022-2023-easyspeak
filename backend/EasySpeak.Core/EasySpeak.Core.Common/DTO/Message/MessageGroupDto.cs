namespace EasySpeak.Core.Common.DTO
{
    public class MessageGroupDto
    {
        public DateTime Date { get; set; }
        public IEnumerable<MessageDto>? Messages { get; set; }
    }
}
