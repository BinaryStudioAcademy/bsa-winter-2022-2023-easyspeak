using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO;
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

    public async Task<ICollection<LessonDto>> GetAllLessonsAsync()
    {
        var lessons = await _context.Lessons
            .Include(l => l.Tags)
            .Include(l => l.Questions)
            .ThenInclude(q => q.Subquestions)
            .ToListAsync();

        return _mapper.Map<ICollection<LessonDto>>(lessons);
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

        var lessonDtos = _mapper.Map<List<Lesson>, List<LessonDto>>(lessons.Result);

        lessonDtos.ForEach(t => t.SubscribersCount = subscribersCountDict.Result[t.Id].SbCount);

        return lessonDtos;
    }

    public async Task<LessonDto> CreateLessonAsync(NewLessonDto lessonDto)
    {
        var lesson = _mapper.Map<Lesson>(lessonDto);

        var createdLesson = _context.Add(lesson).Entity;
        await _context.SaveChangesAsync();

        return _mapper.Map<LessonDto>(createdLesson);
    }
}
