using EasySpeak.Core.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationTestController : ControllerBase
    {
        IFirebaseAuthService _firebaseAuthService;

        public AuthenticationTestController(IFirebaseAuthService firebaseAuthService)
        {
            _firebaseAuthService = firebaseAuthService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_firebaseAuthService.UserId);
        }
    }
}
