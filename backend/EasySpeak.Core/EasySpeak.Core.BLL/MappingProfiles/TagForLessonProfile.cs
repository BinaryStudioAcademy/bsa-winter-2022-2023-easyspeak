using AutoMapper;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class TagForLessonProfile : Profile
{
    public TagForLessonProfile()
    {
        CreateMap<Tag, TagForLessonDto>();
        CreateMap<TagForLessonDto, Tag>();
    }
}