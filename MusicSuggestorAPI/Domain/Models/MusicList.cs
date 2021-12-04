using MusicSuggestorAPI.Domain.Enuns;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Models
{
    public class MusicList
    {
        public MusicList()
        {
            Tracks = new List<Track>();
        }
        public List<Track> Tracks{ get; set; }
    }

    public class Track
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
