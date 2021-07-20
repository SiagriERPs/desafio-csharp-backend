using SiagriPlaylistsChallenge.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.ValueObjects
{
    public class Music : ValueObject<Music>
    {
        public string Name;
        public string Genre;
        public string Artist;
    }
}
