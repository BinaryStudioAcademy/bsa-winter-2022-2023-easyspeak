using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("{userId}")]
    public ActionResult<User> Get(int userId)
    {
        var user = new User()
        {
            FirstName = "Test",
            LastName = "User",
            Email = "testuser@gmail.com",
            Country = Country.Ukraine,
            Language = Language.Ukrainian,
            LanguageLevel = LanguageLevel.B2,
            Sex = Sex.Male
        };

        return Ok(new UserDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Country = user.Country.ToString(),
            Language = user.Language.ToString(),
            EnglishLevel = user.LanguageLevel.ToString(),
            Sex = user.Sex.ToString()
        });
    }

    [HttpPut("{userId}")]
    public ActionResult<UserDto> Update(int userId, UserDto userDto)
    {
        return Ok(userDto);
    }
}