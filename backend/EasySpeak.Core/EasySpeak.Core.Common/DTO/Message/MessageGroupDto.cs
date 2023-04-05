using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.Message
{
    public class MessageGroupDto
    {
        public DateTime Date { get; set; }
        public IEnumerable<MessageDto>? Messages { get; set; }
    }
}
