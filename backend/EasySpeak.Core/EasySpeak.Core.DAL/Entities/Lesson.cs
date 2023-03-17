using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class Lesson: Entity<long>, ICreatedBy
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MediaPath { get; set; } = string.Empty;
        public DateTime StartAt { get; set; }
        public int? LimitOfUsers { get; set; }

        public ICollection<User> Subscribers { get; private set; }
        public ICollection<Tag> Tags { get; private set; }
        public ICollection<Question> Questions { get; private set; }

        public string CreatedBy { get; set; } = string.Empty;
        public Lesson()
        {
            Tags = new List<Tag>();
            Questions = new List<Question>();
            Subscribers = new List<User>();
        }
    }
}
