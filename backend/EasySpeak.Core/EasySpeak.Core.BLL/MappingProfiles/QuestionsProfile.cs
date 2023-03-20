using AutoMapper;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class QuestionsProfile : Profile
{
    public QuestionsProfile()
    {
        CreateMap<Question, QuestionForLessonDto>();
    }
}