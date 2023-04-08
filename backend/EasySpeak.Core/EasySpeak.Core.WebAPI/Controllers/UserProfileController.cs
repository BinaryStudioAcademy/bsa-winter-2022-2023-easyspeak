using EasySpeak.Core.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAvatar()
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            return Ok(await _userService.UploadProfilePhoto(file));
        }
    }
}
