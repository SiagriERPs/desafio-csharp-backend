using Microservice.Dtos;
using Microservice.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Services
{
    public interface IMusicService
    {
        Task<Response<MusicDto>> GetMusicsByGenre(string genre);
    }
}
