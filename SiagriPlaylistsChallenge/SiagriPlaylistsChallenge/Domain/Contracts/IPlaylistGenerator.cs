using SiagriPlaylistsChallenge.Domain.ValueObjects;
using SiagriPlaylistsChallenge.Infrastructure;
using SiagriPlaylistsChallenge.Infrastructure.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.Contracts
{
    /// <summary>
    /// Inicialmente deixei como IPlaylistGenerator<T, V> mas não consegui
    /// fazer Dependency Injection com tipagem genérica :T
    /// </summary>
    /// <typeparam name="T">Playlist output type</typeparam>
    /// <typeparam name="V">Playlist `value` input parameter for generating the musics</typeparam>
    public interface IPlaylistGenerator
    {
        PlaylistDTO GetPlaylistMusics(string genre);
    }
}
