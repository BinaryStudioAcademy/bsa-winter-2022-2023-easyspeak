using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.Filter
{
    public class UserFilterDto
    {
        public string[]? Topics { get; set; }
        public string? Language { get; set; }
        public string[]? LangLevels { get; set; }
        public int? Compatibility { get; set; }
    }
}
