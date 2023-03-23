using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.User
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string LanguageLevel { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
    }
}
