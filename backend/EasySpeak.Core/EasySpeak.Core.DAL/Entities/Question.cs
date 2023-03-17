using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class Question : Entity<long>, ICreatedBy
    {
        public long LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
        public string Topic { get; set; } = string.Empty;

        public ICollection<Subquestion> Subquestions { get; private set; }
        public string CreatedBy { get; set; } = string.Empty;
        public Question()
        {
            Subquestions = new List<Subquestion>();
        }
    }
}
