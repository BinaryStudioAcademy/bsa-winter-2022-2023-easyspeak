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
    private readonly IZoomApiService _zoomApiService;
    private readonly IFirebaseAuthService _authService;
    public const int DaysInWeek = 7;

    public LessonsService(EasySpeakCoreContext context, IMapper mapper, IFirebaseAuthService authService, IZoomApiService zoomApiService) : base(context, mapper)
    {
        _authService = authService;
        _zoomApiService = zoomApiService;
    }

    public async Task<ICollection<LessonDto>> GetAllLessonsAsync(FiltersRequest filtersRequest)
    {
        var tagsIds = filtersRequest.Tags?.Select(x => x.Id).ToList();

        var lessonsFromContext = _context.Lessons
            .Include(l => l.Tags)
            .Include(l => l.User)
            .ThenInclude(user => user.Image)
            .Where(x => x.StartAt.Date == filtersRequest.Date && !x.IsCanceled);

        if (tagsIds is not null && tagsIds.Any())
        {
            lessonsFromContext = lessonsFromContext.Where(x => x.Tags.Any(y => tagsIds.Contains(y.Id)));
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
            t.User.ImagePath = lessonsFromContext.First(lesson => lesson.Id == t.Id).User.Image?.Url;
        });

        return lessonDtos;
    }

    public async Task<ICollection<DayCardDto>?> GetDayCardsOfWeekAsync(RequestDayCardDto requestDto)
    {
        var delta = GetDifferenceBetweenMondayAndTodayDate(requestDto.Date);
        var mondayDate = requestDto.Date.AddDays(-delta).Date;
        var dayCards = await _context.Lessons
            .Where(c => c.StartAt.Date >= mondayDate
                        && c.StartAt.Date <= mondayDate.AddDays(DaysInWeek - 1)
                        && !c.IsCanceled)
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

        if (lessonDto.Tags is not null)
        {
            lesson.Tags = await GetExistingTags(lessonDto.Tags);
        }

        lesson.CreatedBy = _authService.UserId;

        var zoomMeetingLinks = await _zoomApiService.GetMeetingLinks(lesson.Name);

        lesson.ZoomMeetingLink = zoomMeetingLinks.JoinUrl;

        lesson.ZoomMeetingLinkHost = zoomMeetingLinks.HostUrl;

        var createdLesson = _context.Add(lesson).Entity;
        await _context.SaveChangesAsync();

        return _mapper.Map<LessonDto>(createdLesson);
    }
    private Task<List<Tag>> GetExistingTags(ICollection<TagForFiltrationDto> tags)
    {
        return _context.Tags.Where(t => tags
        .Select(tagDto=>tagDto.Id)
        .Contains(t.Id))
            .ToListAsync();
    }

    public async Task<TeacherStatisticsDto> GetTeacherLessonsStatisticsAsync()
    {
        var teacherLessons = await _context.Lessons
                .Where(l => l.CreatedBy == _authService.UserId)
                .Include(l => l.Subscribers)
                .ToListAsync();

        var statistics = teacherLessons.Select(l => new TeacherStatisticsDto
            {
                TotalClasses = teacherLessons.Count,
                CanceledClasses = teacherLessons.Count(l => l.IsCanceled),
                FutureClasses = teacherLessons.Count(l => l.StartAt > DateTime.UtcNow && !l.IsCanceled),

                TotalStudents = teacherLessons.Where(l => l.StartAt < DateTime.UtcNow && !l.IsCanceled)
                                              .SelectMany(l => l.Subscribers)
                                              .Count(),

                NextClass = teacherLessons.Where(l => l.StartAt > DateTime.UtcNow && !l.IsCanceled)
                                          .OrderBy(l => l.StartAt)
                                          .Select(l => (DateTime?)l.StartAt)
                                          .FirstOrDefault(),
        })
        .FirstOrDefault();

        return statistics ?? new TeacherStatisticsDto();
    }

    public async Task<ICollection<DaysWithLessonsDto>> GetLessonsInPeriodAsync(DateTime start, DateTime end)
    {
        var selectedLessons = await _context.Lessons.Where(l => l.CreatedBy == _authService.UserId && l.StartAt > start && l.StartAt < end)
                                                    .Include(l => l.Tags)
                                                    .OrderBy(l => l.StartAt)
                                                    .ToListAsync();
                                                    
        var groupedLessons = selectedLessons.GroupBy(l => l.StartAt.Date)
                                            .Select(d => new DaysWithLessonsDto { LessonsDate = d.Key, Lessons = _mapper.Map<List<Lesson>, List<LessonDto>>(d.ToList()) })
                                            .ToList();

        return groupedLessons;
    }

    public async Task<LessonDto> CancelLessonAsync(int id)
    {
        var lesson = await _context.Lessons.Where(l => l.Id == id && l.CreatedBy == _authService.UserId).FirstOrDefaultAsync();

        lesson!.IsCanceled = true;
        await _context.SaveChangesAsync();

        return _mapper.Map<LessonDto>(lesson);
    }
}