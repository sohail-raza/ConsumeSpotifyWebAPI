using ConsumeSpotifyWebAPI.DAL;
using ConsumeSpotifyWebAPI.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ConsumeSpotifyWebAPI.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _httpClient;
        private readonly ReleaseContext _context;

        public SpotifyService(HttpClient httpClient, ReleaseContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task<IEnumerable<Release>?> GetNewReleases(string countryCode, int limit, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetAsync($"browse/new-releases?country={countryCode}&limit={limit}");

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetNewReleaseResult>(responseStream);


            return responseObject?.albums?.items.Select(i => new Release
            {
                Id = i.id,
                Name = i.name,
                Date = i.release_date,
                Link = i.external_urls.spotify,
                ImageUrl = i.external_urls.spotify,
                Artists = string.Join(",", i.artists.Select(i => i.name))
            });
            


        }
    }
}
