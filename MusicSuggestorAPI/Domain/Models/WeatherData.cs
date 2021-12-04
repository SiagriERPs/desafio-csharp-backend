using Newtonsoft.Json;
using System;

namespace MusicSuggestorAPI
{
    public class WeatherData
    {
        public DateTime Date => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Today, "E. South America Standard Time");
        
        [JsonProperty("main")]
        public Weather Weather { get; set; }

        public float TemperatureF => 32 + (int)(Weather.TemperatureC / 0.5556);

        [JsonProperty("name")]
        public string NameCity { get; set; }

        [JsonProperty("cod")]
        public int StatusCodeResquest { get; set; }
    }

    public class Weather
    {
        [JsonProperty("temp")]
        public float TemperatureC { get; set; }
    }
}
