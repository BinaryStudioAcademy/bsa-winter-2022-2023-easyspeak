namespace EasySpeak.Core.Common.DTO.Lesson;

public class LessonStartDto
{
    public long LessonId { get; set;}

    public string LessonName { get; set; } = string.Empty;

    public long[] Subscribers { get; set; } = Array.Empty<long>();

    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            {"lessonId", LessonId},
            {"lessonName", LessonName},
            {"subscribers", Subscribers}
        };
    }
}