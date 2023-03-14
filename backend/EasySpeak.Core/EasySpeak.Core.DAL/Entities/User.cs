using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class User: Entity<long>
    {
        public Country Country { get; set; }
        public Language Language { get; set; }
        public Timezone Timezone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public string Email { get;set; }
        public string ImagePath { get; set; }
        public Sex Sex { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
        public UserStatus Status { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsBanned { get; set; }

        public ICollection<Chat> Chats { get; private set; }
        public ICollection<Lesson> Lessons { get; private set; }
        public ICollection<Tag> Tags { get; private set; }
        public ICollection<Friend> Friends { get; private set; }
        public ICollection<Notification> Notifications { get; private set; }

        public User()
        {
            Chats = new List<Chat>();
            Lessons = new List<Lesson>();
            Tags = new List<Tag>();
            Friends = new List<Friend>();
            Notifications = new List<Notification>();
        }

    }

    public enum Country
    {

    }
    public enum Language
    {

    }
    public enum Timezone
    {

    }

    public enum Sex
    {
        Male,
        Female,
        NonBinary
    }

    public enum LanguageLevel
    {
        A1,
        A2,
        B1,
        B2,
        C1,
        C2
    }

    public enum UserStatus
    {
        Online,
        Offline,
        Missed,
        NotDisturb
    }
    
}
