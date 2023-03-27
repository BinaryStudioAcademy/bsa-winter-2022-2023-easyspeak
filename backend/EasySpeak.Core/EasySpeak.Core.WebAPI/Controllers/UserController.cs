using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> Get(long userId)
        {
            var user = await _userService.GetUserAsync(userId);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserRegisterDto user)
        {
            var createdUser = await _userService.CreateUser(user);

            return Ok(createdUser);
        }


        [HttpPut("{userId}")]
        public ActionResult<UserDto> Update(int userId, UserDto userDto)
        {
            return Ok(userDto);
        }

    }
}
