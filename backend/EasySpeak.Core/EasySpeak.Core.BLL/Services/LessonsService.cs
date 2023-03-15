using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services;

public class LessonsService : BaseService, ILessonsService
{
    public LessonsService(EasySpeakCoreContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<ICollection<LessonWebDto>> GetAllLessonsAsync(RequestDto requestDto)
    {
        List<LessonWebDto> lessons = new List<LessonWebDto>();

        var lessonsFromContext = await _context.Lessons
            .Include(l => l.Tags)
            .Include(l => l.Questions).ThenInclude(t => t.Subquestions)
            .Include(l => l.Subscribers)
            .Include(l => l.User)
            .ToListAsync();


        var mappedLessons = _mapper.Map<List<Lesson>, List<LessonWebDto>>(lessonsFromContext);
        for (int i = mappedLessons.Count - 1; i >= 0; i--)
        {
            if (mappedLessons[i].StartAt < requestDto.Date)
            {
                mappedLessons.RemoveAt(i);
                continue;
            }

            if (requestDto.LanguageLevels != null && requestDto.LanguageLevels.All(l => l != mappedLessons[i].LanguageLevel))
            {
                mappedLessons.RemoveAt(i);
                continue;
            }

            if (requestDto.Tags != null)
            {
                if (requestDto.Tags.All(tag => mappedLessons[i].Tags.All(t => t != tag)))
                {
                    mappedLessons.RemoveAt(i);
                }
            }
        }

        return mappedLessons;
    }
}