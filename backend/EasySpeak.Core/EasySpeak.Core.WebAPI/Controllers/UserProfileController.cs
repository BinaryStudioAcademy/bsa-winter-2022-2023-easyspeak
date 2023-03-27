using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.UploadFile;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IAzureBlobStorageService _azureBlobStorageService;
        private readonly IFirebaseAuthService _firebaseAuthService;

        public UserProfileController(IAzureBlobStorageService azureBlobStorageService, IFirebaseAuthService firebaseAuthService)
        {
            _azureBlobStorageService = azureBlobStorageService;
            _firebaseAuthService = firebaseAuthService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            var fileDto = new NewFileDto()
            {
                Stream = file.OpenReadStream(),
                FileName = file.FileName,
                FolderPath = "easyspeak-files"
            };
            var res = await _azureBlobStorageService.AddFileAsync(fileDto);
            return Ok(res);
        }
    }
}
