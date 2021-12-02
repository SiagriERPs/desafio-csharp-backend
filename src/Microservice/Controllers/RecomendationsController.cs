using Microservice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecomendationsController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly IMusicService _musicService;

        public RecomendationsController(IWeatherService weatherService, IMusicService musicService)
        {
            _weatherService = weatherService;
            _musicService = musicService;
        }

        /// <summary>
        /// Retornar recomendações de música com base na cidade informada e sua temperatura atual
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("temperature/{city}")]
        public async Task<IActionResult> GetRecomendations(string city)
        {
            var weather = await _weatherService.GetCurrentTemperature(city);

            return StatusCode(weather.StatusCode, weather);
        }

        [HttpGet("musics/{genre}")]
        public async Task<IActionResult> GetMusicByGenre(string genre)
        {
            var musics = await _musicService.GetMusicsByGenre(genre);

            return Ok(musics);
        }
    }
}
