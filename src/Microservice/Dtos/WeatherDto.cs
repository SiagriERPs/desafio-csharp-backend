namespace Microservice.Dtos
{
    public class WeatherDto
    {
        public record Main(decimal temp);

        public Main main { get; set; }
    }
}
