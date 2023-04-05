using AutoMapper;
using EasySpeak.Core.BLL.Helpers;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.BLL.Services;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.Services;
public class ZoomApiService : IZoomApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;
    private readonly string _apiSecret;
    private string? _token;
    private DateTime _tokenExpiration = DateTime.MinValue;

    public ZoomApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = configuration.GetSection("ZoomCredentials:ApiKey").Value;
        _apiSecret = configuration.GetSection("ZoomCredentials:ApiSecret").Value;
    }

    public async Task<ZoomMeetingLinks> GetMeetingLinks(string lessonTopic)
    {
        if (_token == null || DateTime.UtcNow > _tokenExpiration)
        {
            _token = JwtHelper.GenerateAccessToken(_apiKey, _apiSecret);
            _tokenExpiration = DateTime.UtcNow.AddMinutes(90);
        }

        var httpClient = _httpClientFactory.CreateClient();
        AddAuthorizationHeader(httpClient.DefaultRequestHeaders, _token);

        var response = await httpClient.PostAsync(
            "https://api.zoom.us/v2/users/me/meetings",
            GetPostContent(lessonTopic)
        );

        var responseBody = await response.Content.ReadAsStringAsync();
        var meetingLinks = JsonConvert.DeserializeObject<ZoomMeetingLinks>(responseBody);

        return new ZoomMeetingLinks(meetingLinks.JoinUrl, meetingLinks.HostUrl);
    }

    private void AddAuthorizationHeader(HttpRequestHeaders headers, string token)
    {
        headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    private StringContent GetPostContent(string lessonTopic)
    {
        return new StringContent(
                JsonConvert.SerializeObject(new
                {
                    topic = lessonTopic,
                }),
                Encoding.UTF8,
                "application/json"
            );
    }
}
