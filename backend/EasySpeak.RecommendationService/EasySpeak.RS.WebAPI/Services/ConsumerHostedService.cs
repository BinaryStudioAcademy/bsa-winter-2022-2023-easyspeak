using EasySpeak.Core.Common.DTO.Rabbit;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.Common.Options;
using EasySpeak.RabbitMQ.Interfaces;
using EasySpeak.RS.WebAPI.Interfaces;
using Microsoft.Extensions.Options;

namespace EasySpeak.RS.WebAPI.Services;

public class ConsumerHostedService : BackgroundService
{
    private readonly IMessageConsumer _consumer;
    private readonly ILogger<ConsumerHostedService> _logger;
    private readonly IRecommendationService _recommendationService;

    public ConsumerHostedService(IMessageConsumer consumer, ILogger<ConsumerHostedService> logger,
        IRecommendationService recommendationService, IOptions<RabbitQueuesOptions> rabbitOptions)
    {
        _consumer = consumer;
        _logger = logger;
        _consumer.Init(rabbitOptions.Value.RecommendationQueue);
        _recommendationService = recommendationService;
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        await base.StartAsync(cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await base.StopAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        try 
        {
            _consumer.Receive<RecommendationServiceMessageDto>(async (data) =>
            {
                if (data is not null)
                {
                    await SendQuery(data);
                }
            });

            await Task.Delay(-1, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception");
        }
    }

    private async Task SendQuery(RecommendationServiceMessageDto data)
    {
        switch (data.Type)
        {
            case QueryType.StartClass:
                await _recommendationService.AddClass(data.Parameters);
                break;
            case QueryType.AddTags:
                if(data.ParameterList is null) break;
                await _recommendationService.AddTags(data.Parameters, data.ParameterList);
                break;
            case QueryType.AddUser:
                await _recommendationService.AddUser(data.Parameters);
                break;
            case QueryType.UpdateUser:
                await _recommendationService.UpdateUser(data.Parameters);
                break;
        }
    }
}