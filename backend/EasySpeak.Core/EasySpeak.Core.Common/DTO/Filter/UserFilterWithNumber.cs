using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.Filter
{
    public class UserFilterWithNumberDto
    {
        public UserFilterDto Filter { get; set; }
        public int PageNumber { get; set; }
    }
}
