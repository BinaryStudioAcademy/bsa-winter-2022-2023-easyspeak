namespace EasySpeak.Core.Common.DTO.Lesson;

public class DayCardDto
{
    public DateTime Date { get; set; }
    public /*DayOfWeek*/ string? DayOfWeek { get; set; }
    public int MeetingsAmount { get; set; }
}