using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services;

public class TagService : BaseService, ITagService
{
    public TagService(EasySpeakCoreContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public Task<string[]> GetAllTagNames() => _context.Tags.Select(t => t.Name).ToArrayAsync();

}