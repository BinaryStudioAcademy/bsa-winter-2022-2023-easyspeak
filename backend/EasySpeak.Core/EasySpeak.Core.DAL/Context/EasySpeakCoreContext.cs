using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.DAL.Context
{
    public class EasySpeakCoreContext : DbContext
    {
        public DbSet<Sample> Samples => Set<Sample>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Friend> Friends => Set<Friend>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<Chat> Chats => Set<Chat>();
        public DbSet<Lesson> Lessons => Set<Lesson>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Call> Calls => Set<Call>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Subquestion> Subquestions => Set<Subquestion>();


        public EasySpeakCoreContext(DbContextOptions<EasySpeakCoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
            modelBuilder.Seed();
        }
    }
}
