﻿using EasySpeak.Core.BLL.Interfaces;
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
        public async Task<ActionResult<ICollection<LessonWebDto>>> GetAllAsync([FromBody] RequestDto requestDto)
        {
            var lessons = await _lessonsService.GetAllLessonsAsync();
            var tags = requestDto.Tags;
            var date = requestDto.Date;
            var levels = requestDto.LanguageLevels;
            // TODO 

            return Ok(lessons);
        }


    }
}
