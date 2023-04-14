using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.Filter
{
    public class UserFilter
    {
        public TagForFiltrationDto[]? Tags { get; set; }
        public Language[]? Language { get; set; }
        public LanguageLevel[]? LangLevels { get; set; }
        public int Compatibility { get; set; }
    }
}
