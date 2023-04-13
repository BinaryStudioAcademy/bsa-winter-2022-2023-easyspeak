using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class Question : Entity<long>
    {
        public string Topic { get; set; } = string.Empty;

        public ICollection<Subquestion> Subquestions { get; private set; }
        public Question()
        {
            Subquestions = new List<Subquestion>();
        }
    }
}
