using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySpeak.Core.DAL.Context.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Tags)
                .WithMany(t => t.Users);

            builder.HasMany(u => u.Notifications)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Chats)
                .WithMany(c => c.Users);

            builder.HasMany(u => u.Lessons)
                .WithMany(l => l.Subscribers);

            builder.HasMany(u => u.CreatedLessons)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.CreatedBy);

            builder.HasOne(u => u.Image)
                .WithOne(f => f.User)
                .HasForeignKey<User>(u => u.ImageId);
                //.OnDelete(DeleteBehavior.Cascade);

            builder.Property(u => u.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
