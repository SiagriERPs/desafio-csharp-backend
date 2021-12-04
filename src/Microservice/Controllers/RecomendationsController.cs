using Microservice.Dtos;
using Microservice.Filters;
using Microservice.Helpers.Enums;
using Microservice.Helpers.Extensions;
using Microservice.Repositories;
using Microservice.Responses;
using Microservice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecomendationsController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IMusicService _musicService;

        public RecomendationsController(IWeatherRepository weatherRepository, IMusicService musicService)
        {
            _weatherRepository = weatherRepository;
            _musicService = musicService;
        }

        /// <summary>
        /// Retornar recomendações de música com base na cidade informada e sua temperatura atual
        /// </summary>
        /// <param name="city">Nome da cidade</param>
        /// <returns></returns>
        [HttpGet("{city}")]
        public async Task<IActionResult> GetRecomendationsByCity(string city)
        {
            var weather = await _weatherRepository.GetCurrentTemperature(city);
            if (!weather.IsSuccessStatusCode)
                return StatusCode(weather.StatusCode, weather);

            decimal temperature = weather.Data.main.temp;

            var musicResponse = await _musicService.GetMusicsByTemperature(temperature);

            return StatusCode(musicResponse.StatusCode, musicResponse);
        }

        /// <summary>
        /// Retornar recomendações de música com base na latitude e longitude informada e sua temperatura atual
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetRecomendations([FromQuery] WeatherFilter filter)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var weather = await _weatherRepository.GetCurrentTemperature(filter.Latitude.Value, filter.Longitude.Value);
            if (!weather.IsSuccessStatusCode)
                return StatusCode(weather.StatusCode, weather);

            decimal temperature = weather.Data.main.temp;

            var musicResponse = await _musicService.GetMusicsByTemperature(temperature);

            return StatusCode(musicResponse.StatusCode, musicResponse);
        }
    }
}
