using Microservice.Dtos;
using Microservice.Helpers.Enums;
using Microservice.Helpers.Extensions;
using Microservice.Repositories;
using Microservice.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Services
{
    public class MusicService : IMusicService
    {
        private readonly IMusicRepository _musicRepository;

        public MusicService(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        public async Task<Response<MusicDto>> GetMusicsByTemperature(decimal temperature)
        {
            Response<MusicDto> musicResponse;
            if (temperature > 30)
                musicResponse = await _musicRepository.GetMusicsByGenre(EMusicGenre.Party.GetDescription());
            else if (temperature >= 15 && temperature <= 30)
                musicResponse = await _musicRepository.GetMusicsByGenre(EMusicGenre.Pop.GetDescription());
            else if (temperature >= 10 && temperature <= 14)
                musicResponse = await _musicRepository.GetMusicsByGenre(EMusicGenre.Rock.GetDescription());
            else
                musicResponse = await _musicRepository.GetMusicsByGenre(EMusicGenre.Classical.GetDescription());
            return musicResponse;
        }
    }
}
