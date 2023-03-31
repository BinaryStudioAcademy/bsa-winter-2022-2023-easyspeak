using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Tag;
using Microsoft.AspNetCore.Mvc;


namespace EasySpeak.Core.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public Task<TagDto[]> Get() => _tagService.GetAllTags();

    }
}
