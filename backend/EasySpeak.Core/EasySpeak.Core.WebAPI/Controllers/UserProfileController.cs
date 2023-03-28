using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.UploadFile;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IEasySpeakFileService _easySpeakFileService;
        private readonly IFirebaseAuthService _firebaseAuthService;

        public UserProfileController(IEasySpeakFileService easySpeakFileService, IFirebaseAuthService firebaseAuthService)
        {
            _easySpeakFileService = easySpeakFileService;
            _firebaseAuthService = firebaseAuthService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAvatar(IFormFile file)
        {
            var fileDto = new NewEasySpeakFileDto()
            {
                Stream = file.OpenReadStream(),
                FileName = file.FileName
            };
            var res = await _easySpeakFileService.AddFileAsync(fileDto);
            return Ok(res);
        }
    }
}
