using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Context.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Tags)
                .WithMany(t => t.Users);

            builder.HasMany(u=>u.Notifications)
                .WithOne(n=>n.User)
                .HasForeignKey(n=>n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Chats)
                .WithMany(c => c.Users);

            builder.HasMany(u => u.Lessons)
                .WithMany(l => l.Subscribers);

        }
    }
}
