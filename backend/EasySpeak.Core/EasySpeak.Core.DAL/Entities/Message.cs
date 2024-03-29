﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.DAL.Entities
{
    public class Message : AuditEntity<long>
    {
        public long ChatId { get; set; }
        public Chat Chat { get; set; } = null!;
        public string Text { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public bool IsRead { get; set; }
    }
}
