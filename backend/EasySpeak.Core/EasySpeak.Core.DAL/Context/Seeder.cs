using Bogus;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EasySpeak.Core.DAL.Context;

public static class Seeder
{

    public static void Seed(ModelBuilder modelBuilder)
    {
        var user = CreateAdminUser();
        var tags = GenerateTags();
        var lessons = GenerateLessons(user);

        var lessonTag = SeedHelper<Tag, Lesson, long>
           .GetTablesJoin(tags, lessons, 3)
           .Select(x => new LessonTag(x.Item2, x.Item1));
        var tagUser = GenerateTagUser(user);

        modelBuilder.Entity<Tag>().HasData(tags);
        modelBuilder.Entity<Lesson>().HasData(lessons);
        modelBuilder.Entity<User>().HasData(user);
        modelBuilder.Entity("LessonTag").HasData(lessonTag);
        modelBuilder.Entity("TagUser").HasData(tagUser);
    }

    private static User CreateAdminUser()
    {
        return new User
        {
            Id = 1,
            FirstName = "Fred",
            LastName = "Pitt",
            Country = Country.Ad,
            Language = Language.Ha,
            Timezone = Timezone.Abidjan,
            BirthDate = new DateTime(1998, 4, 4, 0, 0, 0, DateTimeKind.Utc),
            Email = "easymeats.service@gmail.com",
            EmojiName = "FP",
            ImageId = null,
            Sex = Sex.Male,
            LanguageLevel = LanguageLevel.C2,
            Status = UserStatus.Offline,
            IsAdmin = true,
            CreatedAt = new DateTime(2023, 3, 4, 0, 0, 0, DateTimeKind.Utc),
        };
    }

    private static IList<TagUser> GenerateTagUser(User user)
    {
        return new List<TagUser>
        {
            new TagUser(user.Id, 1),
            new TagUser(user.Id, 2),
            new TagUser(user.Id, 3),
        };
    }

    private static IList<Lesson> GenerateLessons(User user, int count = 80)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Lesson>()
            .UseSeed(10)
            .RuleFor(l => l.Id, f => f.IndexGlobal)
            .RuleFor(l => l.Name, f => f.Random.Word())
            .RuleFor(l => l.MediaPath, f => f.Image.PicsumUrl())
            .RuleFor(l => l.StartAt, f => f.Date.Between(new DateTime(2023, 4, 1, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 4, 30, 0, 0, 0, DateTimeKind.Utc)))
            .RuleFor(l => l.LimitOfUsers, f => f.Random.Int(20, 200).OrNull(f, .2f))
            .RuleFor(l => l.YoutubeVideoId, f => f.PickRandom(YoutubeTags))
            .RuleFor(l => l.IsCanceled, false)
            .RuleFor(l => l.CreatedBy, f => user.Id)
            .RuleFor(l => l.Questions, l => l.Random.Words(l.Random.Number(1, 6)))
            .RuleFor(l => l.CreatedAt, l => new DateTime(2023, 3, 4, 0, 0, 0, DateTimeKind.Utc))
            .Generate(count);
    }

    private static IList<Tag> GenerateTags()
    {
        var tags = new[]
        {
            ("Arts", "ArtistPalette.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Business", "Briefcase.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Culture", "ClassicalBuilding.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Education", "GraduationCap.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Environment", "Kite.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Fashion", "Dress.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Food", "Sandwich.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Health", "Dna.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("History", "CrossedSwords.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Literature", "Books.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Movies", "ClapperBoard.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Music", "Drum.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Nature", "FourLeafClover.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Philosophy", "FaceWithMonocle.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Politics", "TopHat.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Science", "TestTube.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Social Media", "MobilePhone.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Sports", "BoxingGlove.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Technologies", "Robot.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
            ("Travel", "DesertIsland.svg", new DateTime(2023, 03, 05, 0, 0, 0, DateTimeKind.Utc)),
        };
        return tags.Select((tag, i) => new Tag()
        {
            Id = i + 1,
            Name = tag.Item1,
            ImageUrl = tag.Item2,
            CreatedAt = tag.Item3
        }).ToList();
    }

    private static IList<string> YoutubeTags = new List<string>()
    {
        "GZb6LNwAeRQ",
        "oGQzYnkYwBs",
        "y_IeU_ut2z4",
        "vx_SFqP75hY",
        "N1urEuxzH34",
        "vaeoTDOnRsE",
        "2UHU93KF9k",
        "2eRtd_-WVkM",
        "Fx9dLmhl7nY",
        "Eg0-a22-XBM",
        "INatfKtRXKc",
        "fjWd1qZW6ng",
        "9OnINP-fGm4",
        "iXEqUxwTraI",
        "Rl298m9JZ9M",
        "RGrL8lqg-AU",
        "SmtkrruHmAM",
        "SJ854on-V2I",
        "7B60bwTXFNc",
        "zIfHrp2REWY",
    };
}

public static class SeedHelper<T, K, TK> where T : Entity<TK>
    where K : Entity<TK>
    where TK : struct
{
    public static IEnumerable<(TK, TK)> GetTablesJoin(IList<T> users, IList<K> chats, int dataPerEntity)
    {
        int start = 0;
        int end = dataPerEntity;

        foreach (var user in users)
        {
            for (int i = start; i < end; i++)
            {
                yield return (user.Id, chats[i].Id);
            }

            start += dataPerEntity;
            end += dataPerEntity;
        }
    }
}