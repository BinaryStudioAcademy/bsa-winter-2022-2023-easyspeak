namespace EasySpeak.Core.Common.DTO
{
    public class NewLessonDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MediaPath { get; set; } = string.Empty;
        public DateTime StartAt { get; set; }
        public int? LimitOfUsers { get; set; }
    }
}
