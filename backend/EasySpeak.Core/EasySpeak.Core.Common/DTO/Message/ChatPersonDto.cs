namespace EasySpeak.Core.Common.DTO.Message
{
    public class ChatPersonDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsOnline { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public string LastMessage { get; set; } = string.Empty;
        public int NumberOfUnreadMessages { get; set; }
    }
}
