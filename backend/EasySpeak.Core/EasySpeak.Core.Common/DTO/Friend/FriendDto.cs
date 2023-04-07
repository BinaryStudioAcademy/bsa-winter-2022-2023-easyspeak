using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.Friend
{
    public class FriendDto
    {
        public long UserId { get; set; }
        public long RequesterId { get; set; }
        public string? FriendshipStatus { get; set; }
    }
}
