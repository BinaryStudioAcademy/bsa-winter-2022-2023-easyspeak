﻿using AutoMapper;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.BLL.Helpers;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Entities;
using UserDto = EasySpeak.Core.Common.DTO.User.UserDto;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
            CreateMap<UserRegisterDto, User>()
                .ForMember(user => user.Sex, src => src.MapFrom(userDto => EnumHelper.MapSex(userDto.Sex)))
                .ForMember(user => user.LanguageLevel, 
                src => src.MapFrom(userDto => EnumHelper.MapLanguageLevel(userDto.LanguageLevel)))
                .ForMember(user => user.Language,
                src => src.MapFrom(userDto => EnumHelper.MapLanguage(userDto.Language)))
                .ForMember(user => user.Country,
                src => src.MapFrom(userDto => EnumHelper.MapCountry(userDto.Country)));

        CreateMap<User, UserDto>();
    }
}
