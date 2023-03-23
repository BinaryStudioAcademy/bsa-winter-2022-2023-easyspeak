using System.Text;
using EasySpeak.Core.BLL.Interfaces;

namespace EasySpeak.Core.BLL.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private HttpClient _httpClient;
        public HttpRequestService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, string content)
        {
            return await _httpClient.PostAsync(requestUri, new StringContent(content, Encoding.UTF8, "application/json"));
        }
    }
}
