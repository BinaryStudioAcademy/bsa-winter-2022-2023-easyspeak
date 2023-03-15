using EasySpeak.Core.DAL.Entities.Enums;

namespace EasySpeak.Core.DAL.Entities
{
    public class Lesson : Entity<long>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MediaPath { get; set; } = string.Empty;
        public long UserId { get; set; }
        public User? User { get; set; }
        public DateTime StartAt { get; set; }
        public int? LimitOfUsers { get; set; }
        public LanguageLevel LanguageLevel { get; set; }

        public ICollection<User> Subscribers { get; private set; }
        public ICollection<Tag> Tags { get; private set; }
        public ICollection<Question> Questions { get; private set; }

        public Lesson()
        {
            Tags = new List<Tag>();
            Questions = new List<Question>();
            Subscribers = new List<User>();
        }
    }
}
