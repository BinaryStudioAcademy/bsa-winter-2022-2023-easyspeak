﻿namespace EasySpeak.Core.Common.DTO.Notification
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Type { get; set; }

    }
}