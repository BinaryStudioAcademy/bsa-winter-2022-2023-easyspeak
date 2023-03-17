using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasySpeak.Core.DAL.Context.EntityConfigurations
{
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasMany(l => l.Questions)
                .WithOne(q => q.Lesson)
                .HasForeignKey(q => q.LessonId);

            builder.HasOne(l => l.User)
                .WithOne().OnDelete(DeleteBehavior.NoAction);

            builder.Property(q => q.CreatedAt)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
