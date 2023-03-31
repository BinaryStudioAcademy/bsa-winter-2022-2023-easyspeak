using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services;

public class TagService : BaseService, ITagService
{
    public TagService(EasySpeakCoreContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<TagDto[]> GetAllTags() => _mapper.Map<TagDto[]>(await _context.Tags.ToArrayAsync());

}