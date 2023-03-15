using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class Friend : Entity<long>
    {
        public long UserId { get; set; } // user that accept friend
        public User User { get; set; } = null!;
        public long RequesterId { get; set; } //user that makes a request for friendship
        public User Requester { get; set; } = null!;
        public FriendshipStatus FriendshipStatus { get; set; }
        public DateTime CreatedAt { get; set; }

    }

    public enum FriendshipStatus
    {
        Pending,
        Confirmed,
        Rejected
    }
}
