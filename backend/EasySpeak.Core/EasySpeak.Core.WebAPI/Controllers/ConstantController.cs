using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Tag;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("constants")]
    [ApiController]
    public class ConstantController : ControllerBase
    {
        private readonly IConstantService constantService;

        public ConstantController(IConstantService constantService)
        {
            this.constantService = constantService;
        }

        [HttpGet("tags")]
        public async Task<ActionResult<List<TagWithImageDto>>> GetAllTags()
        {
            return await constantService.GetTagsAsync();
        }

        [HttpGet("languages")]
        public ActionResult<List<string>> GetAllLanguages()
        {
            return constantService.GetLanguages();
        }

        [HttpGet("timezones")]
        public ActionResult<List<string>> GetAllTimezones()
        {
            return constantService.GetTimezones();
        }
    }
}
