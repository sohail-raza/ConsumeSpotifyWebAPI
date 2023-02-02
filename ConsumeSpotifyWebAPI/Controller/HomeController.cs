using ConsumeSpotifyWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace ConsumeSpotifyWebAPI
{
    public class HomeController : Controller
    {
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;
        public HomeController(ISpotifyAccountService _spotifyAccountService, ISpotifyService _spotifyService, IConfiguration configuration)
        {
            this._spotifyAccountService= _spotifyAccountService;
            this._spotifyService = _spotifyService;
            _configuration = configuration;
        }

        [Route("test")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newReleases = await _spotifyService.GetNewReleases("GB", 20,token);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return View();

        }

    }
}
