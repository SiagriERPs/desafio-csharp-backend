using Microservice.Dtos;
using Microservice.Responses;
using System.Threading.Tasks;

namespace Microservice.Repositories
{
    public interface IWeatherRepository
    {
        Task<Response<WeatherDto>> GetCurrentTemperature(string city);
        Task<Response<WeatherDto>> GetCurrentTemperature(decimal latitude, decimal longitude);
    }
}
