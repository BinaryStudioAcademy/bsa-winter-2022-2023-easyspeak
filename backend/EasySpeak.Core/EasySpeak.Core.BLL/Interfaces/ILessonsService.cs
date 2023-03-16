﻿using EasySpeak.Core.Common.DTO.Lesson;

namespace EasySpeak.Core.BLL.Interfaces;

public interface ILessonsService
{
    Task<ICollection<LessonDto>> GetAllLessonsAsync(RequestWithFiltersDto requestWithFiltersDto);
    Task<ICollection<DayCardDto>?> GetDayCardsOfWeekAsync(RequestDayCardDto requestDto);
}