using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IFirebaseAuthService _authService;

        public UsersController(IUserService userService, IFirebaseAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserRegisterDto user)
        {
            var createdUser = await _userService.CreateUser(user);

            return Ok(createdUser);
        }
        
        [HttpGet("{userId}")]
        public ActionResult<ICollection<User>> Get()
        {
            var user = new User()
            {
                FirstName = "Test",
                LastName = "User",
                Email = "testuser@gmail.com",
                LanguageLevel = LanguageLevel.B2,
                Sex = Sex.Male
            };

            return Ok(new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Country = user.Country.ToString(),
                Language = user.Language.ToString(),
                EnglishLevel = user.LanguageLevel.ToString(),
                Sex = user.Sex.ToString(),
            });
        }

        [HttpPut("{userId}")]
        public ActionResult<UserDto> Update(int userId, UserDto userDto)
        {
            return Ok(userDto);
        }

        [HttpPut("enroll/{lessonId}")]
        public Task Enroll(long lessonId) => _userService.EnrollUserToLesson(
            _authService.UserId, lessonId);
    }
}
