using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class Tag : Entity<long>
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<User> Users { get; private set; }
        public ICollection<Lesson> Lessons { get; private set; }

        public Tag()
        {
            Users = new List<User>();
            Lessons = new List<Lesson>();
        }
    }
}
