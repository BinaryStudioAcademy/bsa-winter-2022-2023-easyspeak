using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.Helpers
{
    public static class JwtHelper
    {
        public static string GenerateAccessToken(string apiKey, string apiSecret, int expirationTime = 90)
        {
            var header = new
            {
                alg = "HS256",
                typ = "JWT"
            };

            var payload = new
            {
                iss = apiKey,
                exp = DateTimeOffset.UtcNow.AddMinutes(expirationTime).ToUnixTimeSeconds()
            };

            var encodedHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header)));
            var encodedPayload = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));

            var signature = new HMACSHA256(Encoding.UTF8.GetBytes(apiSecret))
                .ComputeHash(Encoding.UTF8.GetBytes($"{encodedHeader}.{encodedPayload}"));

            var encodedSignature = Convert.ToBase64String(signature);

            return $"{encodedHeader}.{encodedPayload}.{encodedSignature}";
        }
    }
}
