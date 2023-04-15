using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.User
{
    public class UserShortInfoPaginationDto
    {
        public List<UserShortInfoDto> UserShortInfoDtos { get; set; }
        public int FilteredCardsCount { get; set; }
    }
}
