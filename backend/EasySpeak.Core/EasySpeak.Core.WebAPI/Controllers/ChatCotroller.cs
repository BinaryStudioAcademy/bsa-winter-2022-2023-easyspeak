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
        public async Task<ActionResult<List<MessageGroupDto>>> GetChatMessages(long chatId)
        {
            return Ok(await _chatService.GetChatMessages(chatId));
        }

        [HttpGet("checkForChat/{firstUserId}/{secondUserId}")]
        public async Task<ActionResult<long>> CheckIfChatExists(long firstUserId, long secondUserId)
        {
            return Ok(await _chatService.CheckIfChatExists(firstUserId, secondUserId));
        }

        [HttpPost("createChat")]
        public async Task<ActionResult<long>> CreateChat([FromBody] long[] userIds)
        {
            return Ok(await _chatService.CreateChat(userIds[0], userIds[1]));
        }

        [HttpGet("getUnreadMessages/{userId}")]
        public async Task<ActionResult<long>> GetNumberOfUnreadMessages(long userId)
        {
            return Ok(await _chatService.GetNumberOfUnreadMessages(userId));
        }

        [HttpPost("sendMessage")]
        public async Task<ActionResult<NewMessageDto>> SendMessageAsync([FromBody] NewMessageDto message)
        {
            return Ok(await _chatService.SendMessageAsync(message));
        }

        [HttpPut("readMessage")]
        public async Task<ActionResult> ReadMessageAsync([FromBody] long chatId)
        {
            await _chatService.SetMessagesAsRead(chatId);
            return Ok();
        }
    }
}
