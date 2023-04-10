using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Tag;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService dataService;

        public DataController(IDataService constantService)
        {
            this.dataService = constantService;
        }

        [HttpGet("tags")]
        public async Task<ActionResult<List<TagWithImageDto>>> GetAllTags()
        {
            return await dataService.GetTagsAsync();
        }

        [HttpGet("languages")]
        public ActionResult<List<string>> GetAllLanguages()
        {
            return dataService.GetLanguages();
        }
    }
}
