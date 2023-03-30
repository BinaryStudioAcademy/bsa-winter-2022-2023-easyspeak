﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.Common.DTO.User
{
    public class UserShortInfoDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string LanguageLevel { get; set; } = string.Empty;
        public string[] Tags { get; set; } = null!;
        public string ImagePath { get; set; } = string.Empty;
    }
}