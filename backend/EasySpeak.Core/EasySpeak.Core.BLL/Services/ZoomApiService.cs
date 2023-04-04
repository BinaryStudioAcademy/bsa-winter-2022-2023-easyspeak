using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.BLL.Services;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class ZoomApiService : IZoomApiService
{
    private readonly string _apiKey;
    private readonly string _apiSecret;
    private string? _token;
    private DateTime _tokenExpiration = DateTime.MinValue;

    public ZoomApiService(IConfiguration configuration)
    {
        _apiKey = configuration.GetSection("ZoomCredentials:ApiKey").Value;
        _apiSecret = configuration.GetSection("ZoomCredentials:ApiSecret").Value;
    }

    public async Task<ZoomMeetingLinks> GetMeetingLinks(string lessonTopic)
    {
        if (_token == null || DateTime.UtcNow > _tokenExpiration)
        {
            _token = GenerateAccessToken();
            _tokenExpiration = DateTime.UtcNow.AddMinutes(90);
        }

        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            GenerateAccessToken()
        );

        var response = await httpClient.PostAsync(
            "https://api.zoom.us/v2/users/me/meetings",
            new StringContent(
                JsonConvert.SerializeObject(new
                {
                    topic = lessonTopic,
                }),
                Encoding.UTF8,
                "application/json"
            )
        );

        var responseBody = await response.Content.ReadAsStringAsync();
        dynamic meeting = JsonConvert.DeserializeObject(responseBody);

        string joinUrl = meeting.join_url;
        string startUrl = meeting.start_url;

        return new ZoomMeetingLinks(joinUrl, startUrl);
    }

    public string GenerateAccessToken()
    {
        var header = new
        {
            alg = "HS256",
            typ = "JWT"
        };

        var payload = new
        {
            iss = _apiKey,
            exp = DateTimeOffset.UtcNow.AddMinutes(90).ToUnixTimeSeconds()
        };

        var encodedHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header)));
        var encodedPayload = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));

        var signature = new HMACSHA256(Encoding.UTF8.GetBytes(_apiSecret))
            .ComputeHash(Encoding.UTF8.GetBytes($"{encodedHeader}.{encodedPayload}"));

        var encodedSignature = Convert.ToBase64String(signature);

        return $"{encodedHeader}.{encodedPayload}.{encodedSignature}";
    }
}
