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
        public List<string> Musics { get; set; }

        public string City { get; set; }

        public object WeatherData { get; set; }

        public Playlist(Guid Id, List<string> musics, string city, object weatherData)
        {
            Id = Id;
            Musics = musics;
            City = city;
            weatherData = WeatherData;
        }



        public enum PlaylistState
        {
            Creating,
            Ready
        }
    }
}
