using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.DAL.Entities
{
    public class Lesson : AuditEntity<long>
    {
        public string Name { get; set; } = string.Empty;
        public string MediaPath { get; set; } = string.Empty;
        public User? User { get; set; }
        public DateTime StartAt { get; set; }
        public int? LimitOfUsers { get; set; }
        public string YoutubeVideoId { get; set; } = string.Empty;
        public string ZoomMeetingLink { get; set; } = string.Empty;
        public string ZoomMeetingLinkHost { get; set; } = string.Empty;
        public bool IsCanceled { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
        
        public bool IsCalculated { get; set; }

        public ICollection<User> Subscribers { get; private set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Question> Questions { get; private set; }

        public Lesson()
        {
            Subscribers = new List<User>();
            Tags = new List<Tag>();
            Questions = new List<Question>();
            Subscribers = new List<User>();
        }
    }
}
