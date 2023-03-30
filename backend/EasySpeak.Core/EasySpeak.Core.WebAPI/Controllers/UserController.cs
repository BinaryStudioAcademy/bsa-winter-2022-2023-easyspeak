using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.DTO.Filter;
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

        [HttpGet]
        public async Task<ActionResult<UserDto>> Get()
        {
            var userDto = await _userService.GetUserAsync();
            return userDto is null ? NotFound("User was incorrectly registered, please try another one") : Ok(userDto);
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

        [HttpPost("tags")]
        public async Task<ActionResult<UserDto>> AddTagsToUser([FromBody]List<TagDto> tags)
        {
            var user = await _userService.AddTagsAsync(tags);
            
            return Ok(user);
        }

        [HttpPut("enroll/{lessonId}")]
        public Task<LessonDto> Enroll(long lessonId) => _userService.EnrollUserToLesson(lessonId);

        [HttpPost("recommended")]
        public async Task<ActionResult<List<UserShortInfoDto>>> GetSuitableUsers([FromBody] UserFilterDto userFilter)
        {
            return await _userService.GetFilteredUsers(userFilter);
        }

    }
}
