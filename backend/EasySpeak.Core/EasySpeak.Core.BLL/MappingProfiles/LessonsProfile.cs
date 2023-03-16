using AutoMapper;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles;

public sealed class LessonsProfile : Profile
{
    public LessonsProfile()
    {
        CreateMap<Lesson, LessonDto>()
            .ForMember(t => t.SubscribersCount, opt => opt.MapFrom(src => src.Subscribers.Count));
    }
}