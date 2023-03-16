﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.RabbitMQ.Interfaces
{
    public interface IMessageConsumer
    {
        void Recieve<T>(Action<T?> onMessage);
    }
}
