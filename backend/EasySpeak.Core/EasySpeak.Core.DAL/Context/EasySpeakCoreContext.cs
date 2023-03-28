using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EasySpeak.Core.DAL.Context
{
    public class EasySpeakCoreContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
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
        public DbSet<EasySpeakFile> EasySpeakFiles => Set<EasySpeakFile>();

        public EasySpeakCoreContext(DbContextOptions<EasySpeakCoreContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
            modelBuilder.Seed();
        }
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is Entity<long> && (x.State == EntityState.Added));

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var userId = long.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((AuditEntity<long>)entity.Entity).CreatedBy = userId;
                }
            }
        }
    }
}
