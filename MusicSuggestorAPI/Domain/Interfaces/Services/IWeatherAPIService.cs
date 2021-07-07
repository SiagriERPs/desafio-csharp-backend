using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Domain.Interfaces.Repositorys
{
    public interface IWeatherAPIService
    {
        WeatherData GetBy(string nameCity);
        WeatherData GetBy(double lat, double lon);
    }
}
