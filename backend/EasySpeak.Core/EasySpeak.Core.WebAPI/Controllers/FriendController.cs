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
        private readonly IHubContext<FriendHub> hub;
        private readonly IUserService userService;

        public FriendController(IFriendService service, IHubContext<FriendHub> hub, IUserService userService) 
        {
            _service = service;
            this.hub = hub;
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFriendship([FromBody] FriendEmailDto friendDto)
        {
            await _service.AddFriendAsync(friendDto);
            var me = await userService.GetUserAsync();
            await hub.Clients.User(friendDto.Email).SendAsync("Follow", me!.Email);
            return Ok();
        }

        [HttpPut("accept")]
        public async Task<IActionResult> AcceptFriendship([FromBody] FriendEmailDto friendDto)
        {
            await _service.AcceptFriendshipAsync(friendDto);
            var me = await userService.GetUserAsync();
            await hub.Clients.User(friendDto.Email).SendAsync("Accept", me!.Email);
            return Ok();
        }
        [HttpPut("reject")]
        public async Task<IActionResult> RejectFriendship([FromBody] FriendEmailDto friendDto)
        {
            await _service.RejectFriendshipAsync(friendDto);
            var me = await userService.GetUserAsync();
            await hub.Clients.User(friendDto.Email).SendAsync("Reject", me!.Email);
            return Ok();
        }
    }
}
