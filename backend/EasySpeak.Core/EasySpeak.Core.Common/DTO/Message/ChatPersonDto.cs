﻿namespace EasySpeak.Core.Common.DTO
{
    public class ChatPersonDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsOnline { get; set; }
        public DateTime? LastMessageDate { get; set; }
        public bool? IsRead { get; set; }
        public string LastMessage { get; set; } = string.Empty;
        public int? NumberOfUnreadMessages { get; set; }
        public long ChatId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
