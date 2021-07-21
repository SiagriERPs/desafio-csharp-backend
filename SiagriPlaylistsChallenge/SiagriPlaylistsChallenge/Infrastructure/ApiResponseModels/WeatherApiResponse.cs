using Newtonsoft.Json;
using System.Collections.Generic;


namespace SiagriPlaylistsChallenge.Infrastructure.ApiResponseModels
{
    public class WeatherData
    {
        public WeatherData(Temperature temperature, string city, Coordinates coordinates)
        {
            Temperature = temperature;
            City = city;
            Coordinates = coordinates;
        }
        [JsonProperty("main")]
        public Temperature Temperature { get; set; }

        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("name")]
        public string City { get; set; }
    }

    public class Temperature
    {
        public Temperature(double degree)
        {
            Degree = degree;
        }
        [JsonProperty("temp")]
        public double Degree { get; set; }
    }

    public class Coordinates
    {
        public Coordinates(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}