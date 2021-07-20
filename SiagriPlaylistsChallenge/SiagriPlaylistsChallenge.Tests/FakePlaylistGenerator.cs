
using SiagriPlaylistsChallenge.Domain.Contracts;
using SiagriPlaylistsChallenge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Tests
{
    public class FakePlaylistGenerator : IPlaylistGenerator<Music, string>
    {
        private static readonly IEnumerable<Music> _musics = new[]
       {
            new Music {
            Name = "Killing in the Name Of",
            Artist = "Rage Against the Machine",
            Genre = "Rock",

            },
            new Music {
            Name = "Godzilla",
            Artist = "Eminem",
            Genre = "Rap",

            },
            new Music {
            Name = "Some Party Music",
            Artist = "A DJ",
            Genre = "Party",

            },
             new Music {
            Name = "Lithium",
            Artist = "Nirvana",
            Genre = "Rock",

            },
               new Music {
            Name = "Bad Romance",
            Artist = "Lady Gaga",
            Genre = "Pop",

            },
            new Music {
            Name = "Requiem",
            Artist = "Mozart",
            Genre = "Classical",

            },
        };
        public List<Music> GetPlaylistMusics(string parameter)
        {
            List<Music> musics = new() { };

            foreach (var music in _musics)
            {
                if (music.Genre == parameter)
                    musics.Add(music);
            }

            return musics;
        }
    }
}
