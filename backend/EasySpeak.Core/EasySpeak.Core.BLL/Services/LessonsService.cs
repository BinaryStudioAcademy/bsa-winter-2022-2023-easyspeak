using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using EasySpeak.Core.DAL.Entities.Enums;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        var lessonsFromDb = new List<Lesson>
        {
            new Lesson
            {
                User = new User(),
                UserId = 0,
                Description = "1",
                Id=0,
                LanguageLevel = LanguageLevel.A2,
                StartAt = new DateTime(2023,04,12)
            }
        };

        var mappedLessons = _mapper.Map<ICollection<LessonWebDto>>(lessonsFromDb);

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