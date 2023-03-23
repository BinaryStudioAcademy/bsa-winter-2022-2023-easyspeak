using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class Subquestion : Entity<long>
    {
        public long QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public string Text { get; set; } = string.Empty;
    }
}
