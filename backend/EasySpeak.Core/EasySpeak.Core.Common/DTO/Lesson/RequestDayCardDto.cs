using Newtonsoft.Json;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class RequestDayCardDto
{
    [JsonProperty("date", Required = Required.Always)]
    public DateTime Date { get; set; }
}