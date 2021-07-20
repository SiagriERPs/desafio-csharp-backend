using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.Entities
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public List<string> Musics { get; set; }

        public string City { get; set; }



        public enum PlaylistState
        {
            Creating,
            Ready
        }
    }
}
