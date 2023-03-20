namespace EasySpeak.Core.Common.DTO.Lesson;

public class SubQuestionDto
{
    public long Id { get; set; }
    public long QuestionId { get; set; }
    public QuestionForLessonDto? Question { get; set; }
    public string? Text { get; set; }
}