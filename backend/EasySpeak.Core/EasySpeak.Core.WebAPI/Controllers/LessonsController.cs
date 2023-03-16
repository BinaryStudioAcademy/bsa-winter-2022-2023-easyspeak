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
        public async Task<ActionResult<ICollection<LessonDto>>> GetAllAsync([FromBody] FiltersRequest filtersRequest)
        {
            var lessons = await _lessonsService.GetAllLessonsAsync(filtersRequest);

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
