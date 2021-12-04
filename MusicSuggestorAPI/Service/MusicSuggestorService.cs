using Microsoft.Extensions.Configuration;
using MusicSuggestorAPI.Domain.Common;
using MusicSuggestorAPI.Domain.Interfaces;
using MusicSuggestorAPI.Domain.Interfaces.Repositorys;
using MusicSuggestorAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Service
{
    public class MusicSuggestorService : IMusicSuggestorService
    {
        IWeatherAPIService _weatherService;
        ISpotifyAPIService _spotifyService;

        public MusicSuggestorService(IWeatherAPIService weatherService, ISpotifyAPIService spotifyAPIService)
        {
            _weatherService = weatherService;
            _spotifyService = spotifyAPIService;
        }

        public MusicList GetBy(string nameCity)
        {
            var data = _weatherService.GetBy(nameCity);
            var musicType = MusicTypeResolver.GetMusicTypeBy(data.Weather.TemperatureC);
            var musics = _spotifyService.GetBy(musicType);

            return musics;
        }

        public MusicList GetBy(double latitude, double longitude)
        {
            var data = _weatherService.GetBy(latitude, longitude);
            var musicType = MusicTypeResolver.GetMusicTypeBy(data.Weather.TemperatureC);
            var musics = _spotifyService.GetBy(musicType);

            return musics;
        }
    }
}
