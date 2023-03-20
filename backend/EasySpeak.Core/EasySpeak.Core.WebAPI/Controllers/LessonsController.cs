using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.Common.DTO.Lesson;
using Microsoft.AspNetCore.Mvc;

namespace EasySpeak.Core.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonsService _lessonsService;

        public LessonsController(ILessonsService lessonsService)
        {
            _lessonsService = lessonsService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<LessonDto>>> GetAllAsync()
        {
            var lessons = await _lessonsService.GetAllLessonsAsync();
            return Ok(lessons);
        }

        [HttpPost("filters")]
        public async Task<ActionResult<ICollection<LessonDto>>> GetAllAsync([FromBody] FiltersRequest filtersRequest)
        {
            var lessons = await _lessonsService.GetAllLessonsAsync(filtersRequest);

            return Ok(lessons);
        }

        [HttpPost]
        public async Task<ActionResult<LessonDto>> CreateAsync(NewLessonDto lessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var lesson = await _lessonsService.CreateLessonAsync(lessonDto);
            return Ok(lesson);
        }
    }
}
