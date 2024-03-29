﻿using EasySpeak.Core.BLL.Helpers;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using EasySpeak.Domain.Exceptions;

namespace EasySpeak.Core.BLL.Services;
public class ZoomApiService : IZoomApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;
    private readonly string _apiSecret;
    private string? _token;
    private DateTime _tokenExpiration = DateTime.MinValue;
    private readonly string _baseUrl;
    private readonly string _meetingsUrl;

    public ZoomApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = configuration.GetSection("ZoomCredentials:ApiKey").Value;
        _apiSecret = configuration.GetSection("ZoomCredentials:ApiSecret").Value;
        _baseUrl = configuration.GetSection("ZoomApi:baseUrl").Value;
        _meetingsUrl = configuration.GetSection("ZoomApi:meetingsUrl").Value;
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
            _baseUrl + _meetingsUrl,
            GetPostContent(lessonTopic)
        );

        var responseBody = await response.Content.ReadAsStringAsync();
        var meetingLinks = JsonConvert.DeserializeObject<ZoomMeetingLinks>(responseBody);

        return meetingLinks is not null 
            ? new ZoomMeetingLinks(meetingLinks.JoinUrl, meetingLinks.HostUrl) 
            : throw new EasySpeakException("Failed to generate Zoom meeting links.");
    }

    static void AddAuthorizationHeader(HttpRequestHeaders headers, string token)
    {
        headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    static StringContent GetPostContent(string lessonTopic)
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
