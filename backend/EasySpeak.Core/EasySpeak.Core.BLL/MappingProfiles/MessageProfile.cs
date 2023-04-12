using AutoMapper;
using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        CreateMap<Message, NewMessageDto>();
        CreateMap<NewMessageDto, Message>();
    }
}