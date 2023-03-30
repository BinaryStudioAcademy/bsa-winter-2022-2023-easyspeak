using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Lesson;
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


        [HttpPut]
        public Task<UserDto> Update([FromBody] UserDto userDto)
        {
            return _userService.UpdateUser(userDto);
        }

        [HttpPut("enroll/{lessonId}")]
        public Task<LessonDto> Enroll(long lessonId) => _userService.EnrollUserToLesson(lessonId);

        [HttpGet("tags")]
        public Task<string[]> GetTagNames() => _userService.GetUserTags();
    }
}
