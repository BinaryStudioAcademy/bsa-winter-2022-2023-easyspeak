using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("lastsendMessages")]
        public async Task<ActionResult<ICollection<ChatPersonDto>>> GetUnreadAndLastSendMessageAsync()
        {
            return Ok(await _chatService.GetUnreadAndLastSendMessageAsync());
        }

        [HttpGet("chatmessages/{chatId}")]
        public async Task<ActionResult<List<MessageGroupDto>>> GetChatMessages(int chatId)
        {
            return Ok(await _chatService.GetChatMessages(chatId));
        }
    }
}
