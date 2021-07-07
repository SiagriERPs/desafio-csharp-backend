using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MusicSuggestorAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("AuthSpotify/")]
    public class AuthSpotifyController : Controller
    {
        IConfiguration _configuration;
        string _clientSpotifyId;
        string _urlAPI;
        private const string _spotifyAuthURI = "https://accounts.spotify.com/authorize/";
        string _parameters;

        public AuthSpotifyController(IConfiguration configuration)
        {
            _configuration = configuration;
            _clientSpotifyId = _configuration["SpotifyClientId"];
            _urlAPI = _configuration["urlApi"];
            _parameters = $"?client_id={_clientSpotifyId}&response_type=code&redirect_uri={_urlAPI}";
        }

        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {            
             return Redirect(_spotifyAuthURI + _parameters);
        }

        [Route("AuthRequest")]
        [HttpGet]
        public IActionResult AuthRequest([FromQuery] string code)
        {
            
            AuthHelper.CodeSpotifyAuth = code;

            return Redirect("~/swagger");
        }
    }
}
