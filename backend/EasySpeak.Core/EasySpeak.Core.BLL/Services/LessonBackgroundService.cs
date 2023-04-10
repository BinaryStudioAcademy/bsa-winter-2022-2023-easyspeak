using System.Data.Entity;
using EasySpeak.Core.BLL.Options;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.Rabbit;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.Common.Options;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services;

public class LessonBackgroundService : BackgroundService
{
    private readonly IServiceProvider _services;
    private readonly IMessageProducer _messageProducer;
    private readonly RabbitQueuesOptions _rabbitQueues;
    private readonly LessonBackgroundOptions _options;
    
    public LessonBackgroundService(IServiceProvider services, IMessageProducer messageProducer,
        IOptions<RabbitQueuesOptions> rabbitQueues, IOptions<LessonBackgroundOptions> options)
    {
        _services = services;
        _messageProducer = messageProducer;
        _rabbitQueues = rabbitQueues.Value;
        _options = options.Value;
    }
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            using (var scope = _services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();
                
                try
                {
                    IAsyncEnumerable<Lesson> lessons = QueryableExtensions.Include(context.Lessons, l => l.Subscribers)
                        .Where(l => !l.IsCalculated && l.StartAt <= DateTime.Now).AsAsyncEnumerable();

                    await foreach (var lesson in lessons)
                    {
                        if (lesson.Subscribers.Any()) SendLessonStartQuery(lesson);
                        lesson.IsCalculated = true;
                    }
                    
                    await context.SaveChangesAsync(cancellationToken);
                    await Task.Delay(TimeSpan.FromMinutes(_options.DelayInMinutes), cancellationToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    private void SendLessonStartQuery(Lesson lesson)
    {
        var lessonStart = new LessonStartDto()
        {
            LessonId = lesson.Id,
            LessonName = lesson.Name,
            Subscribers = lesson.Subscribers.Select(s => s.Id).ToArray()
        };

        var queryParameters = lessonStart.ToDictionary();

        var messageDto = new RecommendationServiceMessageDto(QueryType.StartClass, queryParameters);
        
        SendQueryToRabbit(messageDto);
    }

    private void SendQueryToRabbit(RecommendationServiceMessageDto data)
    {
        _messageProducer.Init(_rabbitQueues.RecommendationQueue, "");
        _messageProducer.SendMessage(data);
    }
}