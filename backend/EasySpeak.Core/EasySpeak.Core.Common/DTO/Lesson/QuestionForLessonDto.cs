namespace EasySpeak.Core.Common.DTO.Lesson;

public class QuestionForLessonDto
{
    public string Topic { get; set; } = string.Empty;

    public ICollection<SubQuestionDto>? SubQuestions { get; set; }
}

