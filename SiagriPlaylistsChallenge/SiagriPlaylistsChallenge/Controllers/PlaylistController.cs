using Microsoft.AspNetCore.Mvc;
using SiagriPlaylistsChallenge.Domain.Contracts;
using SiagriPlaylistsChallenge.Domain.ValueObjects;

namespace SiagriPlaylistsChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {

        private IWeatherFinder _weatherFinder;
        private IPlaylistGenerator _playlistGenerator;

        public PlaylistController(IWeatherFinder weather, IPlaylistGenerator playlistGenerator)
        {
            _weatherFinder = weather;
            _playlistGenerator = playlistGenerator;
        }

        [HttpGet]
        public IActionResult Get(string city)
        {

            var response = _weatherFinder.GetWeatherData(city);

           


            var temp = response.Temperature.Degree;

            string genre = PlaylistMusics.CoolExaustiveSwitch(temp);

            var musics = _playlistGenerator.GetPlaylistMusics(genre);

            return Ok(musics);
        }
    }
}
