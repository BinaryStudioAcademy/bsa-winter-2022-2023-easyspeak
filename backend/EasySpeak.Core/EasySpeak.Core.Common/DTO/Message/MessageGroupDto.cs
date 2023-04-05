namespace EasySpeak.Core.Common.DTO.Message
{
    public class MessageGroupDto
    {
        public DateTime Date { get; set; }
        public IEnumerable<MessageDto>? Messages { get; set; }
    }
}
