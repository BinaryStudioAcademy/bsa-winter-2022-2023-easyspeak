﻿using AutoMapper;
using EasySpeak.Core.BLL.Helpers;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRegisterDto, User>()
            .ForMember(user => user.Sex, src => src.MapFrom(userDto => EnumHelper.MapSex(userDto.Sex)))
            .ForMember(user => user.LanguageLevel,
            src => src.MapFrom(userDto => EnumHelper.MapLanguageLevel(userDto.LanguageLevel)));

        CreateMap<User, UserDto>()
            .ForMember(userDto => userDto.Sex, src => src.MapFrom(user => EnumHelper.MapSexToString(user.Sex)));
            
        CreateMap<User, UserForLessonDto>();

        CreateMap<UserDto, User>()
            .ForMember(user => user.Sex, src => src.MapFrom(userDto => EnumHelper.MapSex(userDto.Sex)))
            .ForMember(user => user.LanguageLevel,
                src => src.MapFrom(userDto => EnumHelper.MapLanguageLevel(userDto.LanguageLevel)))
            .ForMember(user => user.Tags, src => src.Ignore());

        CreateMap<User, UserShortInfoDto>()
            .ForMember(user => user.Name, src => src.MapFrom(user => $"{user.FirstName} {user.LastName}"))
            .ForMember(user => user.ImagePath, src => src.MapFrom(user => user.GetUserAvatar(user.Image)))
            .ForMember(user => user.Tags, src => src.MapFrom(user => user.Tags.Select(t => t.Name)));
    }
}