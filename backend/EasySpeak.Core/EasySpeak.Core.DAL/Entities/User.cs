using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.DAL.Entities
{
    public class User : Entity<long>
    {
        public Country Country { get; set; }
        public Language Language { get; set; }
        public Timezone Timezone { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public Sex Sex { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
        public UserStatus Status { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsBanned { get; set; }

        public ICollection<Chat> Chats { get; private set; }
        public ICollection<Lesson> Lessons { get; private set; }
        public ICollection<Lesson> CreatedLessons { get; private set; }
        public ICollection<Tag> Tags { get; private set; }
        public ICollection<Friend> Friends { get; private set; }
        public ICollection<Friend> Users { get; private set; }
        public ICollection<Notification> Notifications { get; private set; }
        public User()
        {
            Chats = new List<Chat>();
            Lessons = new List<Lesson>();
            Tags = new List<Tag>();
            Friends = new List<Friend>();
            Users = new List<Friend>();
            Notifications = new List<Notification>();
            CreatedLessons = new List<Lesson>();
        }
    }
}
