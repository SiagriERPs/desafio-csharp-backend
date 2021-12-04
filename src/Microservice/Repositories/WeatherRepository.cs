using Microservice.Dtos;
using Microservice.Responses;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Microservice.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly HttpClient _httpClient;
        private const string API_KEY = "API_KEY";

        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5/weather?";

        public WeatherRepository(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private record ErrorWeather(int cod, string message);

        public async Task<Response<WeatherDto>> GetCurrentTemperature(string city)
        {
            string uri = $"{_baseUrl}q={city}&appid={API_KEY}&units=metric";
            var weatherReponse = await _httpClient.GetAsync(uri);
            if (weatherReponse.IsSuccessStatusCode)
            {
                WeatherDto weather = await weatherReponse.Content.ReadFromJsonAsync<WeatherDto>();
                return new Response<WeatherDto>(weather);
            }
            else
            {
                ErrorWeather error = await weatherReponse.Content.ReadFromJsonAsync<ErrorWeather>();
                Response<WeatherDto> serviceResponse = new()
                {
                    StatusCode = error.cod,
                    Error = error.message,
                };
                return serviceResponse;
            }
        }
        public async Task<Response<WeatherDto>> GetCurrentTemperature(decimal latitude, decimal longitude)
        {
            string uri = $"{_baseUrl}lat={latitude}&lon={longitude}&appid={API_KEY}&units=metric";
            var weatherReponse = await _httpClient.GetAsync(uri);
            if (weatherReponse.IsSuccessStatusCode)
            {
                WeatherDto weather = await weatherReponse.Content.ReadFromJsonAsync<WeatherDto>();
                return new Response<WeatherDto>(weather);
            }
            else
            {
                ErrorWeather error = await weatherReponse.Content.ReadFromJsonAsync<ErrorWeather>();
                Response<WeatherDto> serviceResponse = new()
                {
                    StatusCode = error.cod,
                    Error = error.message,
                };
                return serviceResponse;
            }
        }
    }
}
