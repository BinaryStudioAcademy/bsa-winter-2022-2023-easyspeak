using EasySpeak.Core.DAL.Entities.Enums;
using Newtonsoft.Json;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class FiltersRequest
{
    [JsonProperty(Required = Required.Default)]
    public ICollection<LanguageLevel>? LanguageLevels { get; set; }

    [JsonProperty(Required = Required.Default)]
    public ICollection<TagForLessonDto>? Tags { get; set; }

    [JsonProperty(Required = Required.Always)]
    public DateTime Date { get; set; }
}