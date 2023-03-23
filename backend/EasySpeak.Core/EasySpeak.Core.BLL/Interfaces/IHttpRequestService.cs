using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IHttpRequestService
    {
        public Task<HttpResponseMessage> PostAsync(string requestUri, string content);
    }
}
