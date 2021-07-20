using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.Contracts
{
    /// <summary>
    /// Made this playlist generator contract in a very generic way 
    /// that support domain logic change in the client specifications 
    /// just in case a crazy manager decides to change the service specifications :P
    /// </summary>
    /// <typeparam name="T">Playlist output type</typeparam>
    /// <typeparam name="V">Playlist `value` input parameter for generating the musics</typeparam>
    public interface IPlaylistGenerator<T, V>
    {
        List<T> GetPlaylistMusics(V parameter);
    }
}
