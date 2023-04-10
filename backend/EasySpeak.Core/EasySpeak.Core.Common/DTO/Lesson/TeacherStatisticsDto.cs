namespace EasySpeak.Core.Common.DTO.Lesson;

public class TeacherStatisticsDto
{
    public int TotalClasses { get; set; }
    public int CanceledClasses { get; set; }
    public int FutureClasses { get; set; }
    public int TotalStudents { get; set; }
    public DateTime? NextClass { get; set; }
}

