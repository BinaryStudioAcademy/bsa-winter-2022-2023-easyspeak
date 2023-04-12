namespace EasySpeak.Core.Common.Options;

public class RabbitQueuesOptions
{
    public string NotificationQueue { get; set; } = string.Empty;
    public string RecommendationQueue { get; set; } = string.Empty;
}