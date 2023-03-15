using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class Chat: Entity<long>
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<User> Users { get; private set; }
        public ICollection<Message> Messages { get; private set; }
        public ICollection<Call> Calls { get; private set; }

        public Chat()
        {
            Users = new List<User>();
            Messages = new List<Message>();
            Calls = new List<Call>();
        }
    }
}
