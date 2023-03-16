using EasySpeak.Core.DAL.Entities.Enums;
using Newtonsoft.Json;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class FiltersRequest
{
    public ICollection<LanguageLevel>? LanguageLevels { get; set; }

    public ICollection<TagForLessonDto>? Tags { get; set; }

    [JsonRequired]
    public DateTime Date { get; set; }
}