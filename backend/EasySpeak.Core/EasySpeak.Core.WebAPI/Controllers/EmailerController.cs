using EasySpeak.Core.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EasySpeak.Core.BLL.Interfaces;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailerController : ControllerBase
    {
        private IConfiguration _configuration;
        private IHttpRequestService _httpRequestService;

        public EmailerController(IConfiguration configuration, IHttpRequestService httpRequestService)
        {
            _configuration = configuration;
            _httpRequestService = httpRequestService;
        }

        [HttpPost("Send")]
        public async Task<ActionResult<NewMailDto>> SendEmail(NewMailDto mail)
        {
            var request = await _httpRequestService.PostAsync(_configuration["EmailSendURI"], JsonConvert.SerializeObject(mail));
            return StatusCode((int)request.StatusCode, request);
        }
    }
}
