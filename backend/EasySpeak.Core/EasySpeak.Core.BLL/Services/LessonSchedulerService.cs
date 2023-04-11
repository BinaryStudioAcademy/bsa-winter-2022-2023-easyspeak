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

namespace EasySpeak.Core.BLL.Services;

public class LessonSchedulerService : BackgroundService
{
    private readonly PeriodicTimer _periodicTimer;
    private readonly LessonSchedulerOptions _schedulerOptions;
    private readonly IServiceProvider _services;
    private readonly IMessageProducer _messageProducer;
    private readonly IMapper _mapper;

    public LessonSchedulerService(IServiceProvider services, IMessageProducer messageProducer,
        IOptions<LessonSchedulerOptions> schedulerOptions, IMapper mapper)
    {
        _schedulerOptions = schedulerOptions.Value;
        _periodicTimer = new(TimeSpan.FromMinutes(10));
        _services = services;
        _messageProducer = messageProducer;
        _mapper = mapper;
    }
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (await _periodicTimer.WaitForNextTickAsync(cancellationToken)
               && !cancellationToken.IsCancellationRequested)
        {
            var lessons = await GetLessons(cancellationToken);
            
            var pendingTasks = lessons.Select(ScheduleSubscribersNotification);
            
            await Task.WhenAll(pendingTasks);
        }
    }
    
    private async Task<List<LessonSubscribersNotifyDto>> GetLessons(CancellationToken cancellationToken)
    {
        var currentTime = DateTime.UtcNow;
        var fromTime = currentTime.AddMinutes(30);
        var toTime = currentTime.AddMinutes(120);

        using (var scope = _services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();

            var lessons = await context.Lessons
                .Include(l => l.Subscribers)
                .Include(l => l.User)
                .ToListAsync(cancellationToken);

            var lessonsWithCreatedReminder = await GetCreatedRemindersList();
        
            return lessons.Where(l => l.StartAt >= fromTime && l.StartAt <= toTime
                                                            && !lessonsWithCreatedReminder.Contains(l.Id))
                .Select(x => new LessonSubscribersNotifyDto()
                {
                    Lesson = x,
                    NotifyAfter = (int)(x.StartAt - x.StartAt.AddMinutes(-2).Date)
                        .TotalMinutes
                })
                .OrderBy(x => x.NotifyAfter).ToList();
        }
    } 

    private async Task ScheduleSubscribersNotification(LessonSubscribersNotifyDto shortInfo)
    {
        var pendingTime = TimeSpan.FromMinutes(shortInfo.NotifyAfter);
        await Task.Delay(pendingTime).ContinueWith(async _ =>
        {
            await SendNotificationToSubscriber(shortInfo.Lesson);
        });
    }

    private async Task SendNotificationToSubscriber(Lesson lesson)
    {
        var newNotifications = GetSubscribersNotificationsList(lesson);
        
        await SaveNotification(newNotifications);
        
        await RemindSubscribers(lesson.Id);
    }

    private List<NewNotificationDto> GetSubscribersNotificationsList(Lesson lesson)
    {
        List<NewNotificationDto> newNotifications = new();
        
        foreach (var subscriber in lesson.Subscribers)
        {
            var notification = new NewNotificationDto()
            {
                IsRead = false,
                UserId = subscriber.Id,
                Email = subscriber.Email,
                RelatedTo = lesson.Id,
                CreatedAt = DateTime.UtcNow,
                Type = NotificationType.reminding,
                Text = "The lesson is starting in <strong>30 minutes</strong>! Don't miss it.",
                ImageId = lesson.User!.ImageId
            };

            newNotifications.Add(notification);
        }

        return newNotifications;
    }
    
    private async Task SaveNotification(List<NewNotificationDto> newNotifications)
    {
        using (var scope = _services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();

            var notifications = _mapper.Map<List<Notification>>(newNotifications);
            
            await context.Notifications.AddRangeAsync(notifications);

            await context.SaveChangesAsync();
        }
    }

    public async Task RemindSubscribers(long lessonId)
    {
        using (var scope = _services.CreateAsyncScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();

            var notifications = await context.Notifications
                .Include(n => n.User)
                .Select(n => new
                {
                    Notification = _mapper.Map<NotificationDto>(n), n.User.Email
                })
                .ToListAsync();

            foreach (var item in notifications)
            {
                SendToRabbit(item.Email, item.Notification);
            }
        }
    }

    private async Task<List<long>> GetCreatedRemindersList()
    {
        using (var scope = _services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();

            return await context.Notifications
                .Where(n => n.Type == NotificationType.reminding)
                .Select(n => n.RelatedTo)
                .ToListAsync();
        }
    }
    
    private void SendToRabbit(string email, NotificationDto notification)
    {
        _messageProducer.Init("notifications", "");
        _messageProducer.SendMessage(new Tuple<string, NotificationDto>(email, notification));
    }
}

public class LessonSubscribersNotifyDto
{
    public Lesson Lesson { get; set; } = null!;
    public int NotifyAfter { get; set; }
}