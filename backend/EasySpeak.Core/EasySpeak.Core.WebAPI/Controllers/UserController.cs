using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.User;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> Get()
        {
            var userDto = await _userService.GetUserAsync();

            return Ok(userDto);
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


        [HttpGet("short")]
        public async Task<ActionResult<List<UserShortInfoDto>>> GetSuitableUsers(
            [FromQuery] string? language,
            [FromQuery] string[]? levels,
            [FromQuery] string[]? interests,
            [FromQuery] int? compatibility
            )
        {
            return await _userService.GetFilteredUsers(language, levels, interests, compatibility);
        }

    }
}
