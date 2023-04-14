using System.Data.Entity;
using AutoMapper;
using EasySpeak.Core.BLL.Options;
using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using EntityFrameworkQueryableExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

namespace EasySpeak.Core.BLL.Services;

public class LessonSchedulerService : BackgroundService
{
    private readonly LessonSchedulerOptions _schedulerOptions;
    private readonly IServiceProvider _services;
    private readonly IMessageProducer _messageProducer;
    private readonly IMapper _mapper;
    private readonly PeriodicTimer _periodicTimer;

    public LessonSchedulerService(IServiceProvider services, IMessageProducer messageProducer,
        IOptions<LessonSchedulerOptions> schedulerOptions, IMapper mapper)
    {
        _schedulerOptions = schedulerOptions.Value;
        _services = services;
        _messageProducer = messageProducer;
        _mapper = mapper;
        _periodicTimer = new PeriodicTimer(TimeSpan.FromMinutes(_schedulerOptions.CheckPeriod));
    }
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (await _periodicTimer.WaitForNextTickAsync(cancellationToken) && 
               !cancellationToken.IsCancellationRequested)
        {
            var lessons = await GetLessons(cancellationToken);

            var pendingTasks = lessons.Select(ScheduleSubscribersNotification);

            await Task.WhenAll(pendingTasks);
        }
    }

    private async Task<List<LessonDelayDto>> GetLessons(CancellationToken cancellationToken)
    {
        var currentTime = DateTime.UtcNow;

        var fromTime = currentTime.AddMinutes(_schedulerOptions.CheckPeriod);

        var toTime = currentTime.AddMinutes(_schedulerOptions.CheckPeriod * 2);

        using var scope = _services.CreateScope();
        
        var context = scope.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();

        var lessonsWithCreatedReminder = await GetCreatedRemindersList(cancellationToken);

        var lessons = await EntityFrameworkQueryableExtensions.ToListAsync(context.Lessons
            .Where(l => l.StartAt >= fromTime
                        && l.StartAt <= toTime
                        && lessonsWithCreatedReminder.Contains(l.Id))
            .Select(l => new LessonDelayDto
            {
                LessonId = l.Id,
                DelayInMinutes = (l.StartAt - fromTime).Minutes - currentTime.Minute
            }), cancellationToken);

        return lessons.OrderBy(l => l.DelayInMinutes).ToList();
    } 

    private async Task ScheduleSubscribersNotification(LessonDelayDto lessonDelayDto)
    {
        var pendingTime = TimeSpan.FromMinutes(lessonDelayDto.DelayInMinutes);
        
        await Task.Delay(pendingTime).ContinueWith(async _ =>
        {
            await using var scope = _services.CreateAsyncScope();
            
            var context = scope.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();

            var lessonSubscribers = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(context.Lessons
                .Where(x => lessonDelayDto.LessonId == x.Id)
                .Include(l => l.Subscribers)
                .Include(l => l.User)
                .Select(l => new LessonSubscribersNotifyDto()
                {
                    Lesson = l,
                    Author = l.User!,
                    Subscribers = l.Subscribers.ToList()
                }));

            if (lessonSubscribers is not null) await SendNotificationToSubscriber(lessonSubscribers);
        });
    }

    private async Task SendNotificationToSubscriber(LessonSubscribersNotifyDto shortInfo)
    {
        var newNotifications = GetSubscribersNotificationList(shortInfo);
        
        await SaveNotification(newNotifications);
        
        await RemindSubscribers(shortInfo.Lesson.Id);
    }

    private List<NewNotificationDto> GetSubscribersNotificationList(LessonSubscribersNotifyDto shortInfo)
    {
        shortInfo.Subscribers.Add(shortInfo.Author);

        var newNotifications = shortInfo.Subscribers.Select(CreateNotification).ToList();
        
        return newNotifications;

        NewNotificationDto CreateNotification(User subscriber)
        {
            return new NewNotificationDto
            {
                IsRead = false,
                UserId = subscriber.Id,
                Email = subscriber.Email,
                RelatedTo = shortInfo.Lesson.Id,
                CreatedAt = DateTime.UtcNow,
                Type = NotificationType.reminding,
                Text = "The lesson is starting in <strong>30 minutes</strong>! Don't miss it.",
                ImageId = shortInfo.Author.ImageId
            };
        }
    }
    
    private async Task SaveNotification(List<NewNotificationDto> newNotifications)
    {
        await using var scope = _services.CreateAsyncScope();
        
        var context = scope.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();

        var notifications = _mapper.Map<List<Notification>>(newNotifications);
            
        await context.Notifications.AddRangeAsync(notifications);

        await context.SaveChangesAsync();
    }

    public async Task RemindSubscribers(long lessonId)
    {
        await using var scope = _services.CreateAsyncScope();
        
        var context = scope.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();

        var notifications = await EntityFrameworkQueryableExtensions.ToListAsync(context.Notifications
            .Include(n => n.User)
            .Where(n => n.RelatedTo == lessonId)
            .Select(x => new
            {
                Notification = _mapper.Map<NotificationDto>(x), x.User.Email
            }));

        foreach (var item in notifications)
        {
            SendToRabbit(item.Email, item.Notification);
        }
    }

    private async Task<List<long>> GetCreatedRemindersList(CancellationToken cancellationToken)
    {
        using (var scope = _services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();

            return await EntityFrameworkQueryableExtensions.ToListAsync(context.Notifications
                 .Where(n => n.Type == NotificationType.reminding)
                 .Select(n => n.RelatedTo), cancellationToken);
        }
    }
    
    private void SendToRabbit(string email, NotificationDto notification)
    {
        _messageProducer.Init("notifications", "");
        _messageProducer.SendMessage(new Tuple<string, NotificationDto>(email, notification));
    }
}

public class LessonDelayDto
{
    public long LessonId { get; set; }
    public int DelayInMinutes { get; set; }
}

public class LessonSubscribersNotifyDto
{
    public Lesson Lesson { get; set; } = null!;
    public List<User> Subscribers { get; set; } = new();
    public User Author { get; set; } = null!;
}