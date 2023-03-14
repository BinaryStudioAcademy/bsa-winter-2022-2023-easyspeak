namespace EasySpeak.Core.Common.DTO.Lesson;

public class QuestionForLessonDto
{
    public long Id { get; set; }
    public string Topic { get; set; } = string.Empty;

    public ICollection<SubquestionDto> Subquestions { get; private set; }
}

public class SubquestionDto
{
}