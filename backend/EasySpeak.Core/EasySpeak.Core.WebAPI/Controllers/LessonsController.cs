﻿using EasySpeak.Core.BLL.Interfaces;
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
        [Route("")]
        public async Task<ActionResult<ICollection<LessonWebDto>>> GetAllAsync([FromQuery] RequestDto requestDto)
        {
            var lessons = await _lessonsService.GetAllLessonsAsync(requestDto);
            return Ok(lessons);
        }
    }
}
