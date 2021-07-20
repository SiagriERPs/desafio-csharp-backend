using SiagriPlaylistsChallenge.Domain.Contracts;
using SiagriPlaylistsChallenge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Tests
{
    public class FakeWeatherFinder : IWeatherFinder<double>
    {
        private static readonly IEnumerable<Temperature> _temperatures =
              new[] {
                new Temperature
                {
                    City = "Goiânia",
                    Latitude =  -16.67m,
                    Longitute = -49.25m,
                    Value = 30.2m,
                    Valid = true,

                },
                new Temperature
                {
                    City = "Nova Crixás",
                    Latitude =  -14.10m,
                    Longitute = -50.35m,
                    Value = 60.2m,
                    Valid = true,

                },
                new Temperature
                {
                    City = "Rio Branco",
                    Latitude =  0,
                    Longitute = 0,
                    Value = 0,
                    Valid = false,

                },
                new Temperature
                {
                    City = "Cidade Pop",
                    Latitude =  0,
                    Longitute = 0,
                    Value = 16,
                    Valid = true,

                },
                new Temperature
                {
                    City = "Cidade Rock",
                    Latitude =  0,
                    Longitute = 0,
                    Value = 14,
                    Valid = true,

                },
                new Temperature
                {
                    City = "Cidade Classica",
                    Latitude =  0,
                    Longitute = 0,
                    Value = -5,
                    Valid = true,

                }
              };


        public double GetWeatherData(string cityName)
        {
            var temperature = _temperatures.FirstOrDefault(x => x.City == cityName);

            return temperature.Value;
        }

        public double GetWeatherData(double latitude, double longitude)
        {
            var temperature = _temperatures.FirstOrDefault(x => x.Latitude == latitude && x.Longitute == longitude);


            return temperature.Value;
        }
    }
}
