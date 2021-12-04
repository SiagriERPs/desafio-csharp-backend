using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Models
{
    public class SuggestionMusic
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CityName{ get; set; }
        public string Country { get; set; }
        public List<MusicList> Musics { get; set; }
    }
}
