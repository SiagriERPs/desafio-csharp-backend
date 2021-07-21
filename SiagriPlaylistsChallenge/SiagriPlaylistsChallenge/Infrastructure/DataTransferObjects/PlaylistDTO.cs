using Newtonsoft.Json;
using SiagriPlaylistsChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Infrastructure.DataTransferObjects
{
    public class PlaylistDTO
    {
        public PlaylistDTO()
        {
            Musics = new List<Music>();
        }
        [JsonProperty("tracks")]
        public List<Music> Musics { get; set; }


       
    }

    public class Music
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
