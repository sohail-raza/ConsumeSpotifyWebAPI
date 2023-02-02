using ConsumeSpotifyWebAPI.Models;

namespace ConsumeSpotifyWebAPI.Services
{
    public interface ISpotifyService
    {
        Task<IEnumerable<Release>> GetNewReleases(string countryCode, int limit, string accessToken);
        //Task<IEnumerable<Album>> GetUserSavedAlbums(string limit, string market, string offset, string accessToken);
    }
}
