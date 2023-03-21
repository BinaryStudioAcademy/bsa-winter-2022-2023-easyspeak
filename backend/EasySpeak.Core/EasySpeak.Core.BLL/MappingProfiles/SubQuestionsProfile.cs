using AutoMapper;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class SubQuestionsProfile : Profile
{
    public SubQuestionsProfile()
    {
        CreateMap<Subquestion, SubQuestionDto>();
        CreateMap<SubQuestionDto, Subquestion>();
    }
}