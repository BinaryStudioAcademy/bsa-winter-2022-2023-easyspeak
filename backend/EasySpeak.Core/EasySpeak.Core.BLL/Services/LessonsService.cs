using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services;

public class LessonsService : BaseService, ILessonsService
{
    public LessonsService(EasySpeakCoreContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<ICollection<LessonDto>> GetAllLessonsAsync(RequestWithFiltersDto requestWithFiltersDto)
    {
        var lessonsFromContext = await _context.Lessons
            .Include(l => l.Tags)
            .Include(l => l.Questions).ThenInclude(t => t.Subquestions)
            .Include(l => l.Subscribers)
            .Include(l => l.User)
            .ToListAsync();

        var mappedLessons = _mapper.Map<List<Lesson>, List<LessonDto>>(lessonsFromContext);

        var lessons = mappedLessons
            .Where(m => m.StartAt > requestWithFiltersDto.Date)
            .Where(m => (requestWithFiltersDto.LanguageLevels != null && requestWithFiltersDto.LanguageLevels.Contains(m.LanguageLevel))
                        || requestWithFiltersDto.LanguageLevels == null)
            .Where(m => (requestWithFiltersDto.Tags != null && m.Tags != null && requestWithFiltersDto.Tags.Intersect(m.Tags).Any())
                        || requestWithFiltersDto.Tags == null)
            .ToList();

        return lessons;
    }

    public async Task<ICollection<DayCardDto>?> GetDayCardsOfWeekAsync(RequestDayCardDto requestDto)
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
                    Date = date.Date,
                    DayOfWeek = date.DayOfWeek,
                    MeetingsAmount = meetingAmount
                });
        }

        bool totalAmount = false;
        foreach (var item in listOfWeeksDayCards)
        {
            if (item.MeetingsAmount > 0)
            {
                totalAmount = true;
            }
        }

        return totalAmount ? listOfWeeksDayCards : null;
    }
}