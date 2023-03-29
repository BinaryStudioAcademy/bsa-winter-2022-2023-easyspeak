using AutoMapper;
using EasySpeak.Core.BLL.Helpers;
using EasySpeak.Core.Common.DTO.Filter;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.MappingProfiles
{
    public class UserFilterProfile: Profile
    {
       public UserFilterProfile() 
        {
            CreateMap<UserFilterDto, UserFilter>()
                 .ForMember(filterDto => filterDto.LangLevels,
                src => src.MapFrom(filter => filter.LangLevels != null ? filter.LangLevels.Select(level => EnumHelper.MapLanguageLevel(level)):null));
        }
    }
}
