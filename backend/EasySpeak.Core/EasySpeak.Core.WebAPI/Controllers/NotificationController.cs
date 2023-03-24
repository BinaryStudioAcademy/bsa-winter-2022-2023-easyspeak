using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Notification;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<NotificationDto>>> GetAllAsync()
        {
            var notifications = await _notificationService.GetNotificationsAsync();
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotificationAsync([FromBody] NotificationDto NotificationDto) 
        {
            var notification = await _notificationService.CreateNotificationAsync(NotificationDto);
            return Ok(notification);
        }

        [HttpPut]
        public async Task<IActionResult> ReadNotification([FromBody] long notificationId)
        {
            var id = await _notificationService.ReadNotificationAsync(notificationId);
            return Ok(id);
        }
    }
}
