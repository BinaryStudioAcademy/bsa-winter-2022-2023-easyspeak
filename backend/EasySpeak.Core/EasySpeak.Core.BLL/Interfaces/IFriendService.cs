using EasySpeak.Core.Common.DTO.Friend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IFriendService
    {
        Task<FriendEmailDto> AcceptFriendshipAsync(FriendEmailDto friendDto);
        Task<FriendEmailDto> AddFriendAsync(FriendEmailDto friendDto);
        Task<FriendEmailDto> RejectFriendshipAsync(FriendEmailDto friendDto);
    }
}
