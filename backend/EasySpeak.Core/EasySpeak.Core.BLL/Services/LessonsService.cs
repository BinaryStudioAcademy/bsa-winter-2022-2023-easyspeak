using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using EasySpeak.Core.DAL.Entities.Enums;

namespace EasySpeak.Core.BLL.Services;

public class LessonsService : BaseService, ILessonsService
{
    public LessonsService(EasySpeakCoreContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<ICollection<LessonWebDto>> GetAllLessonsAsync(RequestDto requestDto)
    {
        List<LessonWebDto> lessons = new List<LessonWebDto>();

        //var lessonsFromDb = await _context.Lessons
        //    .Include(l => l.Tags)
        //    .Include(l => l.Questions)
        //    .Include(l => l.Subscribers)
        //    .ToListAsync();

        var q = new Question
        {
            Id = 1,
            Subquestions =
            {
                new Subquestion
                {
                    Id = 3,
                    QuestionId = 1,
                }
            }
        };

        q.Subquestions.FirstOrDefault().Question = q;

        var lessonsFromDb = new List<Lesson>
        {
            new Lesson
            {
                User = new User(),
                UserId = 0,
                Description = "0",
                Id=0,
                LanguageLevel = LanguageLevel.A2,
                StartAt = new DateTime(2023,04,12),
                Tags = new List<Tag> () {new Tag(){Id = 0, Name= "food"}, new Tag(){ Id = 1, Name = "mood"} },
                Questions = { q }
            },
            new Lesson
            {
                User = new User(),
                UserId = 1,
                Description = "1",
                Id=1,
                LanguageLevel = LanguageLevel.A1,
                StartAt = new DateTime(2023,04,13),
                Tags = new List<Tag> () {new Tag(){ Id = 0, Name = "food"}, new Tag(){ Id = 1, Name = "mood"} },
                Questions = { q }
            },

            new Lesson
            {
            User = new User(),
            UserId = 2,
            Description = "2",
            Id=2,
            LanguageLevel = LanguageLevel.A2,
            StartAt = new DateTime(2023,04,13),
            Tags = new List<Tag> () {new Tag(){ Id = 0, Name = "food"}, new Tag(){ Id = 1, Name = "mood"} },
            Questions = { q }
        },
            new Lesson
            {
                User = new User(),
                UserId = 3,
                Description = "3",
                Id=3,
                LanguageLevel = LanguageLevel.B2,
                StartAt = new DateTime(2023,04,13),
                Tags = new List<Tag> () {new Tag(){ Id = 2, Name = "wood"}, new Tag(){ Id = 3, Name = "good"} },
                Questions = { q }
            },
            new Lesson
            {
                User = new User(),
                UserId = 4,
                Description = "4",
                Id=4,
                LanguageLevel = LanguageLevel.B1,
                Subscribers = { new User(){Id = 1}, new User() { Id = 2 } },
                StartAt = new DateTime(2023,04,13),
                Tags = new List<Tag> () {new Tag(){ Id = 4, Name = "cool"}, new Tag(){ Id = 5, Name = "fool"} },
                Questions = { q }
            }
        };

        var mappedLessons = _mapper.Map<List<Lesson>, List<LessonWebDto>>(lessonsFromDb);

        foreach (var lesson in mappedLessons)
        {
            if (lesson.StartAt > requestDto.Date)
            {
                lessons.Add(lesson);
                continue;
            }

            if (requestDto.LanguageLevels != null && requestDto.LanguageLevels.Any(l => l == lesson.LanguageLevel))
            {
                lessons.Add(lesson);
                continue;
            }

            if (requestDto.Tags != null)
            {
                if (requestDto.Tags.Any(tag => lesson.Tags.Any(t => t == tag)))
                {
                    lessons.Add(lesson);
                }
            }
        }

        return lessons;
    }
}