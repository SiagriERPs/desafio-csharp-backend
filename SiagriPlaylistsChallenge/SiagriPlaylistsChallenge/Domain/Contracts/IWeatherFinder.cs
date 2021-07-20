using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.Contracts
{
    public interface IWeatherFinder<T>
    {
        T GetWeatherData(string cityName);

        T GetWeatherData(double latitude, double longitude);
    }
}
