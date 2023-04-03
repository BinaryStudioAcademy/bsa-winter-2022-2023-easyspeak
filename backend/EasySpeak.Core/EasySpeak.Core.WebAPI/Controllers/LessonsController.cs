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
        private readonly IUserService _userService;

        public LessonsController(ILessonsService lessonsService, IUserService userService)
        {
            _lessonsService = lessonsService;
            _userService = userService;
        }

        [HttpGet("{id}/questions")]
        public Task<ICollection<QuestionForLessonDto>> GetQuestionsForLessonAsync(int id) => _lessonsService.GetQuestionsByLessonIdAsync(id);

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
            if (await _userService.GetAdminStatusAsync())
            {
                var lesson = await _lessonsService.CreateLessonAsync(lessonDto);
                return Ok(lesson);
            }
            return StatusCode(403);
        }
    }
}
