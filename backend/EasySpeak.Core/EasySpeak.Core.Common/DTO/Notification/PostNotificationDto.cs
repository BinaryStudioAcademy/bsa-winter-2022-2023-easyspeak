using EasySpeak.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.Notification
{
    public class PostNotificationDto
    {
        public string Email { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Link { get; set; }
    }
}
