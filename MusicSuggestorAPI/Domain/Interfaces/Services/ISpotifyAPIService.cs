using MusicSuggestorAPI.Domain.Enuns;
using MusicSuggestorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Domain.Interfaces.Repositorys
{
    public interface ISpotifyAPIService
    {
        MusicList GetBy(eMusicType musicType);
    }
}
