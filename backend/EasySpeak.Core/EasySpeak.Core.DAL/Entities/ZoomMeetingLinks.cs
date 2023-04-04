using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class ZoomMeetingLinks
    {
        string JoinUrl { get; set; } = string.Empty;
        string HostUrl { get; set; } = string.Empty;

        public ZoomMeetingLinks(string joinUrl, string hostUrl)
        {
            JoinUrl = joinUrl;
            HostUrl = hostUrl;
        }
    }
}
