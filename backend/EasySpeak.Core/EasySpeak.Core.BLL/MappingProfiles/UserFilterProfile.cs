using AutoMapper;
using EasySpeak.Core.BLL.Helpers;
using EasySpeak.Core.Common.DTO.Filter;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.MappingProfiles
{
    public class UserFilterProfile: Profile
    {
       public UserFilterProfile() 
        {
            CreateMap<string, LanguageLevel>()
                .ConstructUsing(level => EnumHelper.MapLanguageLevel(level));
            CreateMap<UserFilterDto, UserFilter>();
        }
    }
}
