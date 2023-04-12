using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.Tag
{
    public class TagWithImageDto: TagDto
    {
        public string ImageUrl { get; set; } = string.Empty;
    }
}
