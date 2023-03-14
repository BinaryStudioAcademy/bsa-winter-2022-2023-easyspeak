using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class Notification : Entity<long>
    {
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public string Text { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
    }

    public enum NotificationType
    {
        Information,
        Error
    }
}
