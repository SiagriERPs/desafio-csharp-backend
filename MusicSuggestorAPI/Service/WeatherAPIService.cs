using Microsoft.Extensions.Configuration;
using MusicSuggestorAPI.Domain.CustomException;
using MusicSuggestorAPI.Domain.Interfaces.Repositorys;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Repositorys
{
    public class WeatherAPIService : IWeatherAPIService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        private string _opeWeatherKey;
        private const string _weatherURI = "https://api.openweathermap.org/data/2.5/";

        public WeatherAPIService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            httpClient.BaseAddress = new Uri(_weatherURI);
            _opeWeatherKey = _configuration["OpenWeatherKey"];

            _httpClient = httpClient;
        }


        public WeatherData GetBy(string nameCity)
        {
            var data = GetWeather(_weatherURI + getURLWeatherParameters(nameCity)).Result;

            if (data is null || data.StatusCodeResquest == (int)HttpStatusCode.NotFound)
                throw new CustomExceptionAPI("Infelizmente não obtivemos resultados em nossa busca pelo nome da cidade informado. Por gentileza, verifique se o nome inserido é correto e tente novamente.", (int)HttpStatusCode.NotFound);

            return data;
        }

        public WeatherData GetBy(double lat, double lon)
        {
            var data = GetWeather(_weatherURI + getURLWeatherParameters(lat, lon)).Result;

            if (data is null || data.StatusCodeResquest == (int)HttpStatusCode.NotFound)
                throw new CustomExceptionAPI("Infelizmente não obtivemos resultados em nossa busca pela geolocalização informada. Por gentileza, verifique as coordenadas inseridas estão corretas e tente novamente.", (int)HttpStatusCode.NotFound);

            return data;
        }

        #region private
        private string getURLWeatherParameters(string nameCity)
        {
            return $"weather?q={nameCity}&appid={_opeWeatherKey}&units=metric";
        }

        private string getURLWeatherParameters(double lat, double lon)
        {
            return $"weather?lat={lat}&lon={lon}&appid={_opeWeatherKey}&units=metric";
        }

        private async Task<WeatherData> GetWeather(string url)
        {
            try
            {
                var response = _httpClient.GetAsync(url).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<WeatherData>(result);
                return data;

            }
            catch (Exception ex)
            {
                throw new CustomExceptionAPI("Serviço de consulta de informações climáticas temporariamente indisponível.", (int)HttpStatusCode.BadGateway);
            }
        }
        #endregion


    }
}
