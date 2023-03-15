using AutoMapper;
using Bogus.DataSets;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services;

public class LessonsService : BaseService, ILessonsService
{
    public LessonsService(EasySpeakCoreContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<ICollection<LessonWebDto>> GetAllLessonsAsync(RequestDto requestDto)
    {
        var lessonsFromContext = await _context.Lessons
            .Include(l => l.Tags)
            .Include(l => l.Questions).ThenInclude(t => t.Subquestions)
            .Include(l => l.Subscribers)
            .Include(l => l.User)
            .ToListAsync();

        var mappedLessons = _mapper.Map<List<Lesson>, List<LessonWebDto>>(lessonsFromContext);
        for (int i = mappedLessons.Count - 1; i >= 0; i--)
        {
            if (mappedLessons[i].StartAt < requestDto.Date)
            {
                mappedLessons.RemoveAt(i);
                continue;
            }

            if (requestDto.LanguageLevels != null &&
                requestDto.LanguageLevels.All(l => l != mappedLessons[i].LanguageLevel))
            {
                mappedLessons.RemoveAt(i);
                continue;
            }

            if (requestDto.Tags != null && requestDto.Tags.All(tag =>
                {
                    var tagForLessonDtos = mappedLessons[i].Tags;
                    return tagForLessonDtos != null && tagForLessonDtos.All(t => t != tag);
                }))
            {
                mappedLessons.RemoveAt(i);
            }
        }

        return mappedLessons;
    }

    public async Task<ICollection<DayCardDto>> GetDayCardsOfWeekAsync(RequestDayCardDto requestDto)
    {
        var lessonsFromContext = await _context.Lessons.ToListAsync();
        var listOfWeeksDayCards = new List<DayCardDto>();

        for (int i = 0; i < 7; i++)
        {
            var date = requestDto.Date.AddDays(i);
            var meetingAmount = lessonsFromContext.Count(l => l.StartAt.Date == requestDto.Date.Date);
            listOfWeeksDayCards.Add(
                new DayCardDto()
                {
                    Date = date,
                    DayOfWeek = date.DayOfWeek,
                    MeetingsAmount = meetingAmount
                });
        }

        return listOfWeeksDayCards;
    }
}