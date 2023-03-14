using Newtonsoft.Json;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class RequestDto
{
    [JsonProperty("languageLevels")]
    public ICollection<LanguageLevelDto> LanguageLevels { get; set; }

    [JsonProperty("tags")]
    public ICollection<TagForLessonDto> Tags { get; set; }

    [JsonRequired]
    [JsonProperty("date")]
    public DateTime Date { get; set; }
}