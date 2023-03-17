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

    public async Task<ICollection<LessonDto>> GetAllLessonsAsync(FiltersRequest filtersRequest)
    {
        var tagsName = filtersRequest.Tags?.Select(x => x.Name);

        var lessonsFromContext = _context.Lessons
            .Include(l => l.Tags)
            .Include(l => l.Questions)
            .Include(l => l.Subscribers)
            .Include(l => l.User)
            .Where(x => x.StartAt > filtersRequest.Date);

        if (tagsName != null)
        {
            lessonsFromContext = lessonsFromContext.Where(x => x.Tags.Any(y => tagsName.Contains(y.Name)));
        }

        if (filtersRequest.LanguageLevels != null)
        {
            lessonsFromContext = lessonsFromContext.Where(m => filtersRequest.LanguageLevels.Contains(m.LanguageLevel));
        }

        return _mapper.Map<List<Lesson>, List<LessonDto>>(await lessonsFromContext.ToListAsync());
    }
}