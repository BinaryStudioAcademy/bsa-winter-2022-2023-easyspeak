﻿using AutoMapper;
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
        var dayCards = await _context.Lessons
            .Where(c => c.StartAt.Date >= requestDto.Date.Date
                        && c.StartAt.Date <= requestDto.Date.AddDays(6).Date
                        )
            .GroupBy(c => c.StartAt.Date)
            .Select(t =>
                new DayCardDto()
                {
                    Date = t.Key,
                    DayOfWeek = t.Key.DayOfWeek.ToString(),
                    MeetingsAmount = t.Count()
                }
            )
            .ToListAsync();

        return dayCards;
    }
}