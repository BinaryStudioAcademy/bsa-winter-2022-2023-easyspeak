﻿using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Friend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [ApiController]
    [Route("friends")]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _service;

        public FriendController(IFriendService service) 
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddFriendship([FromBody] FriendEmailDto friendDto)
        {
            return await _service.AddFriendAsync(friendDto) ? Ok() : BadRequest();
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
