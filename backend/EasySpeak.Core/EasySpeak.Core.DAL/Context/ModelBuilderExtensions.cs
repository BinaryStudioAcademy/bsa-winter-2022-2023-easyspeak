using Bogus;
using EasySpeak.Core.DAL.Context.EntityConfigurations;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LessonConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestionConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FriendConfig).Assembly);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>().HasData(GenerateSamples());
        }

        private static IList<Sample> GenerateSamples(int count = 10)
        {
            Faker.GlobalUniqueIndex = 1;

            return new Faker<Sample>()
                .UseSeed(10)
                .RuleFor(e => e.Id, f => f.IndexGlobal)
                .RuleFor(e => e.Title, f => f.Lorem.Word())
                .RuleFor(e => e.Body, f => f.Lorem.Paragraph())
                .RuleFor(e => e.CreatedBy, f => f.Random.Number(1, 5))
                .RuleFor(e => e.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .Generate(count);
        }
    }
}