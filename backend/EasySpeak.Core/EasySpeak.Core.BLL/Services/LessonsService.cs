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
        var lessonsFromContext = await _context.Lessons
            .Include(l => l.Tags)
            .Include(l => l.Questions).ThenInclude(t => t.Subquestions)
            .Include(l => l.Subscribers)
            .Include(l => l.User)
            .Where(m => m.StartAt > filtersRequest.Date)
            .Where(m =>
                (filtersRequest.LanguageLevels != null &&
                 filtersRequest.LanguageLevels.Contains((LanguageLevelDto)m.LanguageLevel)
                 || filtersRequest.LanguageLevels == null))
            .Where(m => (filtersRequest.Tags != null &&
                         filtersRequest.Tags.Select(t => t.Name).Intersect(m.Tags.Select(t => t.Name).Count() > 0))
                        || filtersRequest.Tags == null);

        await Task.Delay(1);

        var res = lessonsFromContext
            .Where(m => (filtersRequest.Tags != null &&
                         filtersRequest.Tags.Select(t => t.Name).Intersect(m.Tags.Select(t => t.Name)).Any())
                        || filtersRequest.Tags == null).ToList();


        return _mapper.Map<List<Lesson>, List<LessonDto>>(res);
    }
}