using SiagriPlaylistsChallenge.Domain.Contracts;
using SiagriPlaylistsChallenge.Infrastructure.ApiResponseModels;
using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace SiagriPlaylistsChallenge.Infrastructure.Services
{
    public class WeatherFinder : IWeatherFinder
    {
        private HttpClient _httpClient;

      
        private const string _weatherApiBaseUrl = "https://api.openweathermap.org/data/2.5/";
        private string _weatherApiKey;
        public WeatherFinder(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(_weatherApiBaseUrl);
            _weatherApiKey = "9341dc804c79f4e2ed1d0889d42c37a8";

            _httpClient = httpClient;
        }


        public WeatherData GetWeatherData(string city)
        {
            var data = HandleFetchWeather(_weatherApiBaseUrl + $"weather?appid={_weatherApiKey}&q={city}&units=metric").Result;
            return data;
        }

        public WeatherData GetWeatherData(double lat, double lon)
        {
            var data = HandleFetchWeather(_weatherApiBaseUrl + $"weather?appid={_weatherApiKey}&lon={lon}&lat={lat}&units=metric").Result;

            return data;
        }

        private async Task<WeatherData> HandleFetchWeather(string url)
        {
            var res = _httpClient.GetAsync(url).Result;
            var result = res.Content.ReadAsStringAsync().Result;
            var weatherInfo = JsonConvert.DeserializeObject<WeatherData>(result);
            return weatherInfo;
        }

    

    }
}
