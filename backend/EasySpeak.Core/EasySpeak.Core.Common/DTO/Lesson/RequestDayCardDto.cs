using Newtonsoft.Json;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class RequestDayCardDto
{
    [JsonRequired]
    [JsonProperty("date")]
    public DateTime Date { get; set; }
}