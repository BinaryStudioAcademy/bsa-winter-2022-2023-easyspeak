using AutoMapper;
using Bogus.DataSets;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services;

public class LessonsService : BaseService, ILessonsService
{
    private readonly IZoomApiService _zoomApiService;
    private readonly IFirebaseAuthService _authService;
    public const int DaysInWeek = 7;

    public LessonsService(EasySpeakCoreContext context, IMapper mapper, IFirebaseAuthService authService, IZoomApiService zoomApiService) : base(context, mapper)
    {
        _authService = authService;
        _zoomApiService = zoomApiService;
    }

    public async Task<ICollection<QuestionForLessonDto>> GetQuestionsByLessonIdAsync(int id)
    {
        var questions = await _context.Questions.Include(q => q.Subquestions)
                                                .Where(q => q.LessonId == id)
                                                .ToListAsync();

        var questionDtos = _mapper.Map<ICollection<Question>, ICollection<QuestionForLessonDto>>(questions);

        return questionDtos;
    }

    public async Task<ICollection<LessonDto>> GetAllLessonsAsync(FiltersRequest filtersRequest)
    {
        var tagsName = filtersRequest.Tags?.Select(x => x.Name).ToList();

        var lessonsFromContext = _context.Lessons
            .Include(l => l.Tags)
            .Include(l => l.User)
            .Where(x => x.StartAt.Date == filtersRequest.Date);

        if (tagsName is not null && tagsName.Any())
        {
            lessonsFromContext = lessonsFromContext.Where(x => x.Tags.Any(y => tagsName.Contains(y.Name)));
        }

        if (filtersRequest.LanguageLevels is not null && filtersRequest.LanguageLevels.Any())
        {
            lessonsFromContext = lessonsFromContext.Where(m => filtersRequest.LanguageLevels != null && filtersRequest.LanguageLevels.Contains(m.LanguageLevel));
        }

        var subscribersInfoDict = await lessonsFromContext.Select(t =>
            new
            {
                t.Id,
                SbCount = t.Subscribers.Count,
                isSubscribed = t.Subscribers.Any(u => u.Id == _authService.UserId)
            }).ToDictionaryAsync(t => t.Id);
        var lessons = await lessonsFromContext.OrderBy(l => l.StartAt).ToListAsync();

        var lessonDtos = _mapper.Map<List<Lesson>, List<LessonDto>>(lessons);

        lessonDtos.ForEach(t =>
        {
            t.SubscribersCount = subscribersInfoDict[t.Id].SbCount;
            t.isSubscribed = subscribersInfoDict[t.Id].isSubscribed;
        });

        return lessonDtos;
    }

    public async Task<ICollection<DayCardDto>?> GetDayCardsOfWeekAsync(RequestDayCardDto requestDto)
    {
        var delta = GetDifferenceBetweenMondayAndTodayDate(requestDto.Date);
        var mondayDate = requestDto.Date.AddDays(-delta).Date;
        var dayCards = await _context.Lessons
            .Where(c => c.StartAt.Date >= mondayDate
                        && c.StartAt.Date <= mondayDate.AddDays(DaysInWeek - 1))
            .GroupBy(c => c.StartAt.Date)
            .Select(t =>
                new DayCardDto
                {
                    Date = t.Key,
                    MeetingsAmount = t.Count()
                }
            )
            .ToListAsync();

        return dayCards;
    }

    private static int GetDifferenceBetweenMondayAndTodayDate(DateTime date)
    {
        if(date.DayOfWeek == DayOfWeek.Sunday)
        {
            return 6;
        }
        return date.DayOfWeek - DayOfWeek.Monday;
    }

    public async Task<LessonDto> CreateLessonAsync(NewLessonDto lessonDto)
    {
        var lesson = _mapper.Map<Lesson>(lessonDto);
        lesson.Tags.Clear();
        if (lessonDto.Tags is not null)
        {
            lesson.Tags = await GetExistingTags(lessonDto.Tags);
        }

        var zoomMeetingLinks = await _zoomApiService.GetMeetingLinks(lesson.Name);

        lesson.ZoomMeetingLink = zoomMeetingLinks.JoinUrl;

        lesson.ZoomMeetingLinkHost = zoomMeetingLinks.HostUrl;

        var createdLesson = _context.Add(lesson).Entity;
        await _context.SaveChangesAsync();

        return _mapper.Map<LessonDto>(createdLesson);
    }

    private Task<List<Tag>> GetExistingTags(ICollection<TagForLessonDto> tags)
    {
        return _context.Tags.Where(t => tags.Any(tag => tag.Name == t.Name)).ToListAsync();
    }
}
