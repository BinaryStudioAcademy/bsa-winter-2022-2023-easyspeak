using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Friend;
using EasySpeak.Core.WebAPI.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [ApiController]
    [Route("friends")]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _service;

        public FriendController(IFriendService service, IUserService userService) 
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddFriendship([FromBody] FriendEmailDto friendDto)
        {
            await _service.AddFriendAsync(friendDto);
            return Ok();
        }

        [HttpPut("accept")]
        public async Task<IActionResult> AcceptFriendship([FromBody] FriendEmailDto friendDto)
        {
            await _service.AcceptFriendshipAsync(friendDto);
            return Ok();
        }
        [HttpPut("reject")]
        public async Task<IActionResult> RejectFriendship([FromBody] FriendEmailDto friendDto)
        {
            await _service.RejectFriendshipAsync(friendDto);
            return Ok();
        }
    }
}
