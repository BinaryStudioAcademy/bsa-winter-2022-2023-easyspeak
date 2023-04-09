using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.Common.DTO.Lesson;

namespace EasySpeak.Core.BLL.Interfaces;

public interface ILessonsService
{
    Task<ICollection<QuestionForLessonDto>> GetQuestionsByLessonIdAsync(int id);
    Task<ICollection<LessonDto>> GetAllLessonsAsync(FiltersRequest filtersRequest);

    Task<ICollection<DayCardDto>?> GetDayCardsOfWeekAsync(RequestDayCardDto requestDto);

    Task<LessonDto> CreateLessonAsync(NewLessonDto lessonDto);
    Task<TeacherStatisticsDto> GetTeacherLessonsStatisticsAsync();
    Task<ICollection<DaysWithLessonsDto>> GetLessonsInPeriodAsync(DateTime start, DateTime end);
    Task<LessonDto> CancelLessonAsync(int id);
}