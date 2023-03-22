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
    public class FriendConfig : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(f => f.Friends)
                .HasForeignKey(f => f.UserId);

            builder.HasOne(u => u.Requester)
                .WithMany(f => f.Users)
                .HasForeignKey(f => f.RequesterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(f => f.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
