using EasySpeak.Core.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAvatar(IFormFile file)
        {
            return Ok(await _userService.UploadProfilePhoto(file));
        }
    }
}
