using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.Common.DTO.Rabbit;

public class RecommendationServiceMessageDto
{
    public QueryType Type { get; set; }
    public Dictionary<string, object> Parameters { get; set; } = new();
    public string[]? ParameterList { get; set; }
}