﻿using AutoMapper;
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

    public async Task<ICollection<LessonDto>> GetAllLessonsAsync(FiltersRequest filtersRequest)
    {
        var tagsName = filtersRequest.Tags?.Select(x => x.Name);

        var lessonsFromContext = _context.Lessons
            .Include(l => l.Tags)
            .Include(l => l.Questions)
            .Include(l => l.User)
            .Where(x => x.StartAt > filtersRequest.Date);

        if (tagsName != null)
        {
            lessonsFromContext = lessonsFromContext.Where(x => x.Tags.Any(y => tagsName.Contains(y.Name)));
        }

        if (filtersRequest.LanguageLevels != null)
        {
            lessonsFromContext = lessonsFromContext.Where(m => filtersRequest.LanguageLevels.Contains(m.LanguageLevel));
        }

        // Create 2 queries
        var subscribersCountDict = lessonsFromContext.Select(t => new { Id = t.Id, SbCount = t.Subscribers.Count }).ToDictionaryAsync(t => t.Id);
        var lessons = lessonsFromContext.ToListAsync();

        await Task.WhenAll(subscribersCountDict, lessons);

        var lessonsAwaited = await lessons;
        var subscribersCountDictAwaited = await subscribersCountDict;

        var lessonDtos = _mapper.Map<List<Lesson>, List<LessonDto>>(lessonsAwaited);

        foreach (var lesson in lessonDtos)
        {
            lesson.SubscribersCount = subscribersCountDictAwaited[lesson.Id].SbCount;
        }

        return lessonDtos;
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