using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Notification;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("notifications")]
        public async Task<ActionResult<ICollection<NotificationDto>>> GetAllAsync()
        {
            var notifications = await _notificationService.GetNotificationsAsync();
            return Ok(notifications);
        }

        [HttpPost("notification")]
        public async Task<IActionResult> CreateNotificationAsync([FromBody] NotificationDto notificationDto) 
        {
            var notification = await _notificationService.CreateNotificationAsync(notificationDto);
            return Ok(notification);
        }

        [HttpPut("readnotification")]
        public async Task<IActionResult> ReadNotification([FromBody] long notificationId)
        {
            var id = await _notificationService.ReadNotificationAsync(notificationId);
            return Ok(id);
        }
    }
}
