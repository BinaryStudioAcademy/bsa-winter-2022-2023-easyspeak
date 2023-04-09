using AutoMapper;
using EasySpeak.Core.BLL.Helpers;
using EasySpeak.Core.Common.DTO.Friend;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.MappingProfiles
{
    public class FriendProfile : Profile
    {
       public FriendProfile() 
        {
            CreateMap<FriendDto, Friend>()
           .ForMember(friend => friend.FriendshipStatus, src => src.MapFrom(friendDto => EnumHelper.MapFriendshipStatus(friendDto.FriendshipStatus!)));

            CreateMap<Friend, FriendEmailDto>();
        }
    }
}
