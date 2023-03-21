using EasySpeak.Core.Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailerController : ControllerBase
    {
        private HttpClient _httpClient;

        public EmailerController()
        {
            _httpClient = new HttpClient();
        }

        [HttpPost("Send")]
        public async Task<ActionResult<NewMailDto>> SendEmail(NewMailDto mail)
        {
            await _httpClient.PostAsync<NewMailDto>(mail);
            return Ok();
        }
    }
}
