using AutoMapper;
using EasySpeak.Core.BLL.Converters.Enum;
using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class NotificationsProfile : Profile
{
    public NotificationsProfile()
    {
        CreateMap<NewNotificationDto, Notification>().ReverseMap();

        CreateMap<NotificationDto, Notification>().ReverseMap();

        CreateMap<NewNotificationDto, NotificationDto>().ReverseMap();
        
        CreateMap<NotificationType, string>().ConvertUsing<EnumToStringConverter<NotificationType>>();
    }
}