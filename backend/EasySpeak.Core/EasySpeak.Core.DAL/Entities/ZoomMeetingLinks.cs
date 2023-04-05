using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class ZoomMeetingLinks
    {
        [JsonProperty("join_url")]
        public string JoinUrl { get; set; }

        [JsonProperty("start_url")]
        public string HostUrl { get; set; }

        public ZoomMeetingLinks(string joinUrl, string hostUrl)
        {
            JoinUrl = joinUrl;
            HostUrl = hostUrl;
        }
    }
}
