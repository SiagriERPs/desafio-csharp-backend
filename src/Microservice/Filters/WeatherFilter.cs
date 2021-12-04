using System.ComponentModel.DataAnnotations;

namespace Microservice.Filters
{
    public class WeatherFilter
    {
        [Required]
        public decimal? Latitude { get; set; }
        [Required]
        public decimal? Longitude { get; set; }
    }
}
