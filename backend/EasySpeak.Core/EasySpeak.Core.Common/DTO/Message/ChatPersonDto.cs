using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.Message
{
    public class ChatPersonDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsOnline { get; set; }
        public string LastMessage { get; set; } = string.Empty;
        public int NumberOfUnreadMessages { get; set; }
    }
}
