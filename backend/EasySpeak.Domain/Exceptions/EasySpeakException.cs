using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Domain.Exceptions
{
    [Serializable]
    public class EasySpeakException : Exception
    {
        public EasySpeakException(string message) : base(message)
        {
        }
    }

}
