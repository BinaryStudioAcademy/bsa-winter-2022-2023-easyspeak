using EasySpeak.Core.Common.DTO.Lesson;

namespace EasySpeak.Core.BLL.Interfaces;

public interface ILessonsService
{
    Task<ICollection<LessonWebDto>> GetAllLessonsAsync(RequestDto requestDto);
    Task<ICollection<DayCardDto>?> GetDayCardsOfWeekAsync(RequestDayCardDto requestDto);
}