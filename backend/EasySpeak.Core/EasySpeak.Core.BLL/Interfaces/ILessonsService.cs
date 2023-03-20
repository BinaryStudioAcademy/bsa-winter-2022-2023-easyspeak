using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.Common.DTO.Lesson;

namespace EasySpeak.Core.BLL.Interfaces;

public interface ILessonsService
{
    Task<ICollection<LessonDto>> GetAllLessonsAsync();

    Task<ICollection<LessonDto>> GetAllLessonsAsync(FiltersRequest filtersRequest);

    Task<LessonDto> CreateLessonAsync(NewLessonDto lessonDto);
}