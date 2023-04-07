
using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class UserForLessonDto
{
    public Country Country { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ImagePath { get; set; }
}