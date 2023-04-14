using System.Data.Entity;
using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.BLL.Options;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Entities;
using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace EasySpeak.Core.BLL.Services;

public class LessonSchedulerService : BackgroundService
{
    private readonly IServiceProvider _services;
    private readonly IMessageProducer _messageProducer;
    private readonly IMapper _mapper;
    private readonly PeriodicTimer _periodicTimer;

    public LessonSchedulerService(IServiceProvider services, IMessageProducer messageProducer,
        IOptions<LessonSchedulerOptions> schedulerOptions, IMapper mapper)
    {
        _services = services;
        _messageProducer = messageProducer;
        _mapper = mapper;
        _periodicTimer = new PeriodicTimer(TimeSpan.FromMinutes(schedulerOptions.Value.CheckPeriod));
    }
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (await _periodicTimer.WaitForNextTickAsync(cancellationToken) && 
               !cancellationToken.IsCancellationRequested)
        {
            await using var scope = _services.CreateAsyncScope();

            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
            
            var lessonService = scope.ServiceProvider.GetRequiredService<ILessonsService>();

            var lessonsWithReminders = await notificationService.GetCreatedRemindersList();

            var lessons = await lessonService.GetLessonsWithDelayTime(lessonsWithReminders);

            var pendingTasks = lessons.Select(l => ScheduleSubscribersNotification(l, lessonService, notificationService));

            await Task.WhenAll(pendingTasks);
        }
    }

    private async Task ScheduleSubscribersNotification(LessonDelayDto lessonDelayDto, ILessonsService lessonsService, INotificationService notificationService)
    {
        var pendingTime = TimeSpan.FromMinutes(lessonDelayDto.DelayInMinutes);
        
        await Task.Delay(pendingTime).ContinueWith(async _ =>
        {
            var lessonWithSubscribers = await lessonsService.GetLessonById(lessonDelayDto.LessonId);

            await SendNotificationToSubscriber(lessonWithSubscribers, notificationService);
        });
    }

    private async Task SendNotificationToSubscriber(Lesson lesson, INotificationService notificationService)
    {
        var newNotifications = GetSubscribersNotificationList(lesson);

        await notificationService.SaveNotificationsRange(newNotifications);
        
        await RemindSubscribers(lesson.Id, notificationService);
    }

    private List<NewNotificationDto> GetSubscribersNotificationList(Lesson lesson)
    {
        lesson.Subscribers.Add(lesson.User!);

        var newNotifications = lesson.Subscribers.Select(CreateNotification).ToList();
        
        return newNotifications;

        NewNotificationDto CreateNotification(User subscriber)
        {
            return new NewNotificationDto
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
        }
    }

    public async Task RemindSubscribers(long lessonId, INotificationService notificationService)
    {
        var reminders = await notificationService.GetReminderNotificationByLesson(lessonId);

        var reminderMessages = reminders.Select(x => new
        {
            Notification = _mapper.Map<NotificationDto>(x), x.User.Email
        });

        foreach (var item in reminderMessages)
        {
            SendToRabbit(item.Email, item.Notification);
        }
    }

    private void SendToRabbit(string email, NotificationDto notification)
    {
        _messageProducer.Init("notifications", "");
        _messageProducer.SendMessage(new Tuple<string, NotificationDto>(email, notification));
    }
}