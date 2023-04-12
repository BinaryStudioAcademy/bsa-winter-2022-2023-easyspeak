using EasySpeak.Core.Common.Enums;
using Newtonsoft.Json;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class FiltersRequest
{
    public ICollection<LanguageLevel>? LanguageLevels { get; set; }

    public ICollection<TagForFiltrationDto>? Tags { get; set; }

    [JsonRequired]
    public DateTime Date { get; set; }
}