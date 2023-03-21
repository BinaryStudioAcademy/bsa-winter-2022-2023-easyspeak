using EasySpeak.Core.Common.DTO;
using EasySpeak.Emailer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailerController : ControllerBase
    {
        private IMailService _mailService;
        public EmailerController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("Send")]
        public async Task<ActionResult<NewMailDto>> SendEmail(NewMailDto mail)
        {
            //await _mailService.SendEmailAsync(mail.To, mail.Subject, mail.Content);
            return Ok();
        }
    }
}
