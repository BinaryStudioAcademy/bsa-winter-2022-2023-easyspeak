using EasySpeak.Core.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
            _httpClient.BaseAddress = new Uri("https://localhost:7109/api/emailer/send");
        }

        [HttpPost("Send")]
        public async Task<ActionResult<NewMailDto>> SendEmail(NewMailDto mail)
        {
            var request = await _httpClient.PostAsync("", new StringContent(JsonConvert.SerializeObject(mail), Encoding.UTF8, "application/json"));
            return StatusCode((int)request.StatusCode, request);
        }
    }
}
