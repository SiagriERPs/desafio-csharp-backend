using SiagriPlaylistsChallenge.Infrastructure.ApiResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.Contracts
{
    public interface IWeatherFinder
    {
        WeatherData GetWeatherData(string cityName);

        WeatherData GetWeatherData(double latitude, double longitude);
    }
}
