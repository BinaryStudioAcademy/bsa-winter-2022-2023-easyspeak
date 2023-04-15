using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.Interfaces;

public interface ILessonsService
{
    Task<ICollection<LessonDto>> GetAllLessonsAsync(FiltersRequest filtersRequest);

    Task<ICollection<DayCardDto>?> GetDayCardsOfWeekAsync(RequestDayCardDto requestDto);

    Task<LessonDto> CreateLessonAsync(NewLessonDto lessonDto);
    Task<TeacherStatisticsDto> GetTeacherLessonsStatisticsAsync();
    Task<ICollection<DaysWithLessonsDto>> GetLessonsInPeriodAsync(DateTime start, DateTime end);
    Task<LessonDto> CancelLessonAsync(int id);
    Task<List<LessonDelayDto>> GetLessonsWithDelayTime(List<long> createdReminders);
    Task<Lesson> GetLessonById(long id);
}