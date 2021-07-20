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
        PlaylistMusics<Music> Musics { get; set; }


     

        public Playlist(PlaylistId id, PlaylistMusics<Music> musics, object weatherData)
        {
            Id = id;
            Musics = musics;
        
        }



        public enum PlaylistState
        {
            Creating,
            Ready
        }
    }
}
