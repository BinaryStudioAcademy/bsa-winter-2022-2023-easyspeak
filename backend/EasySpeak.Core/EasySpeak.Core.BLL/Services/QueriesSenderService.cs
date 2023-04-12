using EasySpeak.Core.Common.DTO.Rabbit;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.Common.Options;
using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.Extensions.Options;

namespace EasySpeak.Core.BLL.Services;

public class QueriesSenderService
{
    private readonly IMessageProducer _messageProducer;
    private readonly RabbitQueuesOptions _rabbitQueues;
    
    public QueriesSenderService(IMessageProducer messageProducer, IOptions<RabbitQueuesOptions> rabbitQueues)
    {
        _messageProducer = messageProducer;
        _rabbitQueues = rabbitQueues.Value;
    }
    
    public void SendAddUserQuery(long id, UserDto user)
    {
        var queryParams = new RecommendationServiceMessageDto(QueryType.AddUser, user.ToDictionary());
        
        queryParams.Parameters.Add("id", id);
        
        SendQueryToRabbit(queryParams);
    }

    public void SendAddTagsQuery(long id, List<TagDto> tags)
    {

        var queryParams = new RecommendationServiceMessageDto()
        {
            Type = QueryType.AddTags,
            Parameters = new Dictionary<string, object>()
            {
                {"id", id}
            },
            ParameterList = tags.Select(x => x.Name).ToArray()
        };

        SendQueryToRabbit(queryParams);
    }

    private void SendQueryToRabbit(RecommendationServiceMessageDto data)
    {
        _messageProducer.Init(_rabbitQueues.RecommendationQueue, "");
        _messageProducer.SendMessage(data);
    }
}