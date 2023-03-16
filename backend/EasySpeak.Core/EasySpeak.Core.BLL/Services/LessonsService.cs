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

    public async Task<ICollection<LessonDto>> GetAllLessonsAsync(FiltersRequest filtersRequest)
    {

        // IQueryable
        var lessonsFromContext = await _context.Lessons
            .Include(l => l.Tags)
            .Include(l => l.Questions).ThenInclude(t => t.Subquestions)
            .Include(l => l.Subscribers)
            .Include(l => l.User)
            .Where(m => m.StartAt > filtersRequest.Date)
            .Where(m =>
                (filtersRequest.LanguageLevels != null &&
                 filtersRequest.LanguageLevels.Contains(m.LanguageLevel)
                 || filtersRequest.LanguageLevels == null)).ToListAsync();

        // IEnumerable
        lessonsFromContext = lessonsFromContext
            .Where(m => (filtersRequest.Tags != null &&
                         filtersRequest.Tags.Select(t => t.Name).Intersect(m.Tags.Select(t => t.Name)).Any()
                         || filtersRequest.Tags == null)).ToList();

        return _mapper.Map<List<Lesson>, List<LessonDto>>(lessonsFromContext);
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

        var notNullResponse = listOfWeeksDayCards.Count(t => t.MeetingsAmount > 0) > 0;

        return notNullResponse ? listOfWeeksDayCards : null;
    }
}