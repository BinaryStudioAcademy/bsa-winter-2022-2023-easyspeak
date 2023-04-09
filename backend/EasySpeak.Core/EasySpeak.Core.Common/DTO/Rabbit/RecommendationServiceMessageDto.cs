using EasySpeak.Core.Common.Converters;
using EasySpeak.Core.Common.Enums;
using Newtonsoft.Json;

namespace EasySpeak.Core.Common.DTO.Rabbit;

public class RecommendationServiceMessageDto
{
    public QueryType Type { get; set; }
    public Dictionary<string, object> Parameters { get; set; } = new();
    
    [JsonConverter(typeof(ListStringConverter))]
    public List<string>? ParameterList { get; set; } = new();
}