using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.Common.DTO
{
    public class NewLessonDto
    {
        public string Name { get; set; } = string.Empty;
        public string MediaPath { get; set; } = string.Empty;
        public DateTime StartAt { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
        public int? LimitOfUsers { get; set; }
        public string YoutubeVideoId { get; set; } = string.Empty;
        public UserForLessonDto? User { get; set; }
        public ICollection<TagForLessonDto>? Tags { get; set; }
        public ICollection<QuestionForLessonDto>? Questions { get; set; }
    }
}
