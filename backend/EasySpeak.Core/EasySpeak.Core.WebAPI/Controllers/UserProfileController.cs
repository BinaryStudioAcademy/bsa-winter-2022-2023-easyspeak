using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.UploadFile;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IFirebaseAuthService _firebaseAuthService;

        public UserProfileController(IUserService userService, IFirebaseAuthService firebaseAuthService)
        {
            _userService = userService;
            _firebaseAuthService = firebaseAuthService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAvatar(IFormFile file)
        {
            return Ok(await _userService.UploadProfilePhoto(file, _firebaseAuthService.UserId));
        }
    }
}
