using Bogus;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.DAL.Context;

public static class Seeder
{
    private static readonly DateTime DefaultDate = new DateTime(2023, 3, 30, 11, 0, 0, DateTimeKind.Utc);
    private static readonly Random Rnd = new Random(42);

    public static void Seed(ModelBuilder modelBuilder)
    {
        var users = GenerateUsers();
        var lessons = GenerateLessons();
        var chats = GenerateChats();
        var tags = GenerateTags();

        var friends = GenerateFriends()
            .AddForeignKeys(users, 5);

        var notifications = GenerateNotitficetions()
            .AddForeingKeys(users, 5);

        var questions = GenerateQuestions()
            .AddForeignKeys(lessons, 10);

        var subquestions = GenerateSubquestions()
            .AddForeignKeys(questions, 20);

        var calls = GenerateCalls()
            .AddForeignKeys(chats, 20);

        var messages = GenerateMessages()
            .AddForeignKeys(chats, 20);


        var chatUser = SeedHelper<User, Chat, long>
            .GetTablesJoin(users, chats, 4)
            .Select(x => new ChatUser(x.Item1, x.Item2));

        var lessonTag = SeedHelper<Lesson, Tag, long>
            .GetTablesJoin(lessons, tags, 2)
            .Select(x => new LessonTag(x.Item1, x.Item2));

        var lessonUser = SeedHelper<User, Lesson, long>
            .GetTablesJoin(users, lessons, 2)
            .Select(x => new LessonUser(x.Item1, x.Item2));

        var tagUser = SeedHelper<User, Tag, long>
            .GetTablesJoin(users, tags, 4)
            .Select(x => new TagUser(x.Item1, x.Item2));

        modelBuilder.Entity<Tag>().HasData(tags);
        modelBuilder.Entity<Lesson>().HasData(lessons);
        modelBuilder.Entity<Question>().HasData(questions);
        modelBuilder.Entity<Subquestion>().HasData(subquestions);
        modelBuilder.Entity<Call>().HasData(calls);
        modelBuilder.Entity<Chat>().HasData(chats);
        modelBuilder.Entity<Message>().HasData(messages);
        modelBuilder.Entity<Notification>().HasData(notifications);
        modelBuilder.Entity<Friend>().HasData(friends);
        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity("ChatUser").HasData(chatUser);
        modelBuilder.Entity("LessonTag").HasData(lessonTag);
        modelBuilder.Entity("LessonUser").HasData(lessonUser);
        modelBuilder.Entity("TagUser").HasData(tagUser);
    }

    private static IList<Friend> GenerateFriends(int count = 20)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Friend>()
            .UseSeed(10)
            .RuleFor(fr => fr.Id, f => f.IndexGlobal)
            .RuleFor(fr => fr.FriendshipStatus, f => f.PickRandom<FriendshipStatus>())
            .Generate(count);
    }

    private static IList<Notification> GenerateNotitficetions(int count = 40)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Notification>()
            .UseSeed(10)
            .RuleFor(n => n.Id, f => f.IndexGlobal)
            .RuleFor(n => n.Text, f => f.Lorem.Sentence())
            .RuleFor(n => n.IsRead, f => f.Random.Bool(.15f))
            .RuleFor(n => n.Type, f => f.PickRandom<NotificationType>())
            .Generate(count);
    }

    private static IList<Subquestion> GenerateSubquestions(int count = 40)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Subquestion>()
            .UseSeed(10)
            .RuleFor(s => s.Id, f => f.IndexGlobal)
            .RuleFor(s => s.Text, f => f.Lorem.Sentences(f.Random.Number(1, 5)))
            .Generate(count);
    }

    private static IList<Question> GenerateQuestions(int count = 20)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Question>()
            .UseSeed(10)
            .RuleFor(q => q.Id, f => f.IndexGlobal)
            .RuleFor(q => q.Topic, f => f.Random.Words(f.Random.Number(1, 6)))
            .Generate(count);
    }

    private static IList<Call> GenerateCalls(int count = 40)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Call>()
            .UseSeed(10)
            .RuleFor(c => c.Id, f => f.IndexGlobal)
            .RuleFor(c => c.StartedAt, f => f.Date.Recent(1, DefaultDate))
            .RuleFor(c => c.FinishedAt,
                (f, c) => f.Date.Between(c.StartedAt, c.StartedAt.AddMinutes(180)).OrNull(f, 0.15f))
            .RuleFor(c => c.ChatId, f => f.Random.Number(1, 40))
            .Generate(count);
    }

    private static IList<Message> GenerateMessages(int count = 40)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Message>()
            .UseSeed(10)
            .RuleFor(m => m.Id, f => f.IndexGlobal)
            .RuleFor(m => m.Text, f => f.Random.Words(f.Random.Number(1, 20)))
            .RuleFor(m => m.CreatedAt, f => f.Date.Recent(7, DefaultDate))
            .RuleFor(m => m.IsDeleted, f => f.Random.Bool(.15f))
            .RuleFor(m => m.ChatId, f => f.Random.Number(1, 40))
            .Generate(count);
    }

    private static IList<Chat> GenerateChats(int count = 20)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Chat>()
            .UseSeed(10)
            .RuleFor(c => c.Id, f => f.IndexGlobal)
            .RuleFor(c => c.Name, f => f.Random.Words(f.Random.Number(1, 3)))
            .Generate(count);
    }

    private static IList<Lesson> GenerateLessons(int count = 10)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Lesson>()
            .UseSeed(10)
            .RuleFor(l => l.Id, f => f.IndexGlobal)
            .RuleFor(l => l.Name, f => f.Random.Word())
            .RuleFor(l => l.Description, f => f.Random.Words(f.Random.Number(2, 10)))
            .RuleFor(l => l.MediaPath, f => f.Image.PicsumUrl())
            .RuleFor(l => l.StartAt, f => f.Date.Soon(30, DefaultDate))
            .RuleFor(l => l.LimitOfUsers, f => f.Random.Int(20, 200).OrNull(f, .2f))
            .Generate(count);
    }

    private static IList<Tag> GenerateTags(int count = 20)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Tag>()
            .UseSeed(10)
            .RuleFor(t => t.Id, f => f.IndexGlobal)
            .RuleFor(t => t.Name, f => f.Random.Word())
            .Generate(count);
    }

    private static IList<User> GenerateUsers(int count = 5)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<User>()
            .UseSeed(10)
            .RuleFor(u => u.Id, f => f.IndexGlobal)
            .RuleFor(u => u.FirstName, f => f.Person.FirstName)
            .RuleFor(u => u.LastName, f => f.Person.LastName)
            .RuleFor(u => u.Email, f => f.Person.Email)
            .RuleFor(u => u.BirthDate, f => f.Person.DateOfBirth = new DateTime(2003, 6, 5))
            .RuleFor(u => u.Sex, f => f.PickRandom<Sex>())
            .RuleFor(u => u.LanguageLevel, f => f.PickRandom<LanguageLevel>())
            .RuleFor(u => u.Country, f => f.PickRandom<Country>())
            .RuleFor(u => u.Language, f => f.PickRandom<Language>())
            .RuleFor(u => u.Timezone, f => f.PickRandom<Timezone>())
            .RuleFor(u => u.Status, f => f.PickRandom<UserStatus>())
            .RuleFor(u => u.IsBanned, f => f.Random.Bool(.1f))
            .RuleFor(u => u.IsSubscribed, f => f.Random.Bool(.9f))
            .RuleFor(u => u.IsAdmin, f => f.Random.Bool(.9f))
            .Generate(count);
    }

    private static IList<Friend> AddForeignKeys(this IList<Friend> friends, IList<User> users, int count)
    {
        foreach (var friend in friends)
        {
            friend.UserId = users[Rnd.Next(count)].Id;
            friend.RequesterId = users[Rnd.Next(count)].Id;
        }

        return friends;
    }

    private static IList<Notification> AddForeingKeys(this IList<Notification> notifications, IList<User> users,
        int count)
    {
        foreach (var notification in notifications)
        {
            notification.UserId = users[Rnd.Next(count)].Id;
        }

        return notifications;
    }

    private static IList<Question> AddForeignKeys(this IList<Question> questions, IList<Lesson> lessons, int count)
    {
        foreach (var question in questions)
        {
            question.LessonId = lessons[Rnd.Next(count)].Id;
        }

        return questions;
    }

    private static IList<Subquestion> AddForeignKeys(this IList<Subquestion> subquestions,
        IList<Question> questions, int count)
    {
        foreach (var subquestion in subquestions)
        {
            subquestion.QuestionId = questions[Rnd.Next(count)].Id;
        }

        return subquestions;
    }

    private static IList<Call> AddForeignKeys(this IList<Call> calls, IList<Chat> chats, int count)
    {
        foreach (var call in calls)
        {
            call.ChatId = chats[Rnd.Next(count)].Id;
        }

        return calls;
    }

    private static IList<Message> AddForeignKeys(this IList<Message> messages, IList<Chat> chats, int count)
    {
        foreach (var message in messages)
        {
            message.ChatId = chats[Rnd.Next(count)].Id;
        }

        return messages;
    }
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