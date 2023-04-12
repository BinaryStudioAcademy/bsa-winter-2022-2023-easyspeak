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
        Task AcceptFriendshipAsync(FriendEmailDto friendDto);
        Task<bool> AddFriendAsync(FriendEmailDto friendDto);
        Task RejectFriendshipAsync(FriendEmailDto friendDto);
    }
}
