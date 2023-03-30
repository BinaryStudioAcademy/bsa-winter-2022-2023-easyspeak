using AutoMapper;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<Tag, TagDto>().ReverseMap();
    }
}