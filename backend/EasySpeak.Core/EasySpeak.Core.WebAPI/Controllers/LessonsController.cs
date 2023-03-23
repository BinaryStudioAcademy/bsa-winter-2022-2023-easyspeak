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

        [HttpGet("{id}/questions")]
        public Task<ActionResult<ICollection<QuestionForLessonDto>>> GetQuestionsForLessonAsync(int id) => _lessonsService.GetQuestionsByLessonIdAsync(id);

        [HttpPost("filters")]
        public async Task<ActionResult<ICollection<LessonDto>>> GetAllAsync([FromBody] FiltersRequest filtersRequest)
        {
            var lessons = await _lessonsService.GetAllLessonsAsync(filtersRequest);
            return Ok(lessons);
        }

        [HttpGet("week")]
        public Task<ICollection<DayCardDto>> GetDayCardAsync([FromQuery] RequestDayCardDto requestDto)
            => _lessonsService.GetDayCardsOfWeekAsync(requestDto)!;

        [HttpPost]
        public async Task<ActionResult<LessonDto>> CreateAsync(NewLessonDto lessonDto)
        {
            var lesson = await _lessonsService.CreateLessonAsync(lessonDto);
            return Ok(lesson);
        }
    }
}
