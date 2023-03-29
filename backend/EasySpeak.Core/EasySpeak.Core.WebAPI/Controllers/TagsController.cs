using EasySpeak.Core.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public Task<string[]> Get() => _tagService.GetAllTagNames();

    }
}
