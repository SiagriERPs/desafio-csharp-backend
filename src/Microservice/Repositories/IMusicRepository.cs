using Microservice.Dtos;
using Microservice.Responses;
using System.Threading.Tasks;

namespace Microservice.Repositories
{
    public interface IMusicRepository
    {
        Task<Response<MusicDto>> GetMusicsByGenre(string genre);
    }
}
