using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult<User> Get()
    {
        var user = new User()
        {
            FirstName = "Test",
            LastName = "User",
            Email = "testuser@gmail.com",
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

    [HttpPut]
    public ActionResult<UserDto> Update(UserDto userDto)
    {
        return Ok(userDto);
    }
}