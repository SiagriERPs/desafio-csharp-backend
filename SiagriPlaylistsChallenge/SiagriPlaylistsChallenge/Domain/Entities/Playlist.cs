using SiagriPlaylistsChallenge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.Entities
{
    public class Playlist
    {
        public PlaylistId Id { get; set; }
        PlaylistMusics<string> Musics { get; set; }


        public object WeatherData { get; set; }

        public Playlist(PlaylistId id, PlaylistMusics<string> musics, object weatherData)
        {
            Id = id;
            Musics = musics;
            weatherData = WeatherData;
        }



        public enum PlaylistState
        {
            Creating,
            Ready
        }
    }
}
