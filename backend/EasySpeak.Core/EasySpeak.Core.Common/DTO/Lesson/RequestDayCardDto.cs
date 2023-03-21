using Newtonsoft.Json;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class RequestDayCardDto
{
    [JsonRequired]
    public DateTime Date { get; set; }
}