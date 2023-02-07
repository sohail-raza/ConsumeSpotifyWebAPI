using ConsumeSpotifyWebAPI.DAL;
using ConsumeSpotifyWebAPI.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ConsumeSpotifyWebAPI.Services
{
    public class SpotifyAccountService : ISpotifyAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly ReleaseContext _context;
        public SpotifyAccountService(HttpClient httpClient, ReleaseContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }
        public async Task<string> GetToken(string clientId, string clientSecret)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "token");  //token is the relative path
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"))); //string combines client id and secret, encodes in base64
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type","client_credentials" }
            });

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<AuthResult>(responseStream);
            return authResult.access_token;
        }
    }
}
