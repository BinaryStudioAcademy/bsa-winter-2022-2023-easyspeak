using AutoMapper;
using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles;

public sealed class LessonsProfile : Profile
{
    public LessonsProfile()
    {
        CreateMap<Lesson, LessonWebDto>()
            .ForMember(t => t.LanguageLevel, opt => opt.MapFrom(src => src.LanguageLevel))
            .ForMember(t => t.Subscribers, opt => opt.MapFrom(src => src.Subscribers.Count))
            .ForMember(t => t.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(t => t.User, opt => opt.MapFrom(src => src.User))
            .ForMember(t => t.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(t => t.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(t => t.MediaPath, opt => opt.MapFrom(src => src.MediaPath))
            .ForMember(t => t.StartAt, opt => opt.MapFrom(src => src.StartAt))
            .ForMember(t => t.Tags, opt => opt.MapFrom(src => src.Tags))
            .ForMember(t => t.Questions, opt => opt.MapFrom(src => src.Questions));
    }

}