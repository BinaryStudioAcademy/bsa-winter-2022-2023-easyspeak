using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Core.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<NotificationDto>>> GetAllAsync()
        {
            var notifications = await _notificationService.GetNotificationsAsync();
            return Ok(notifications);
        }

        [HttpPut]
        public async Task<IActionResult> ReadNotification([FromBody] long notificationId)
        {
            var id = await _notificationService.ReadNotificationAsync(notificationId);
            return Ok(id);
        }
        
        [HttpPut("readAll")]
        public async Task<IActionResult> ReadAllNotification()
        {
            await _notificationService.ReadAllNotificationsAsync();
            return Ok();
        }
    }
}
