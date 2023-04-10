namespace EasySpeak.Core.Common.DTO.Lesson;

public class DaysWithLessonsDto
{
    public DateTime LessonsDate { get; set; }
    public ICollection<LessonDto>? Lessons { get; set; }
}