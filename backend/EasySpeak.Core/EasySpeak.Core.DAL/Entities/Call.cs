using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class Call : Entity<long>
    {
        public long ChatId { get; set; }
        public Chat Chat { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
