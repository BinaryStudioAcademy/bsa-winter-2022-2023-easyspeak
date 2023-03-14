using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.Services;

public class LessonsService : BaseService, ILessonsService
{
    public LessonsService(EasySpeakCoreContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<ICollection<LessonWebDto>> GetAllLessonsAsync(RequestDto requestDto)
    {
        List<Lesson> lessons = new List<Lesson>();

        foreach (var requestDtoLanguageLevel in requestDto.LanguageLevels)
        {
            _context.Lessons.Where(l => l.LanguageLevel)
        }

        var samples = await _context.Lessons.Where(l => l.LanguageLevel)
        return _mapper.Map<ICollection<LessonWebDto>>(samples);
    }

}