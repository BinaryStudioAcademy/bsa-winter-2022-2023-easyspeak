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
         
    }
}
