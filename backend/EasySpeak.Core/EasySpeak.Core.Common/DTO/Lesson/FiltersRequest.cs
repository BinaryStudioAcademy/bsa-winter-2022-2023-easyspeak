using Newtonsoft.Json;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class FiltersRequest
{
    [JsonProperty("languageLevels", Required = Required.Default)]
    public ICollection<LanguageLevelDto>? LanguageLevels { get; set; }

    [JsonProperty("tags", Required = Required.Default)]
    public ICollection<TagForLessonDto>? Tags { get; set; }

    [JsonRequired]
    [JsonProperty("date")]
    public DateTime Date { get; set; }
}