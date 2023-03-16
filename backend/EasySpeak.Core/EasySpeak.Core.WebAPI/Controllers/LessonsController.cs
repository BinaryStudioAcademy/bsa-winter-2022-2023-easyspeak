using EasySpeak.Core.BLL.Interfaces;
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

        [HttpPost("filters")]
<<<<<<< HEAD

        public async Task<ActionResult<ICollection<LessonWebDto>>> GetAllAsync([FromBody] RequestDto requestDto)
=======
        public async Task<ActionResult<ICollection<LessonDto>>> GetAllAsync([FromBody] RequestWithFiltersDto requestWithFiltersDto)
>>>>>>> 23-endpoints-ещ-get-list-of-lessons
        {
            var lessons = await _lessonsService.GetAllLessonsAsync(requestWithFiltersDto);

            return Ok(lessons);
        }

        [HttpGet("week")]

        public async Task<ActionResult<ICollection<DayCardDto>>> GetDayCardAsync([FromQuery] RequestDayCardDto requestDto)
        {
            var lessons = await _lessonsService.GetDayCardsOfWeekAsync(requestDto);
            return Ok(lessons);
        }
    }
}
