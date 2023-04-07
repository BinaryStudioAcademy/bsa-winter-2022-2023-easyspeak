using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Core.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [ApiController]
    [Route("notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;
        private readonly IMapper mapper;

        public NotificationController(INotificationService notificationService, IUserService userService, IMapper mapper)
        {
            _notificationService = notificationService;
            _userService = userService;
            this.mapper = mapper;
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

        [HttpPost]
        public async Task<ActionResult<NotificationDto>> AddNotification([FromBody] PostNotificationDto newNotification)
        {
            long id = await _userService.GetUserIdByEmail(newNotification.Email);
            var notification = await _notificationService.AddNotificationAsync(mapper.Map<NotificationType>(newNotification.Type), id);
            return Ok(notification);
        }
    }
}
