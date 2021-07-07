using MusicSuggestorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Domain.Interfaces
{
    public interface IMusicSuggestorService
    {
        MusicList GetBy(string nameCity);
        MusicList GetBy(double latitude, double longitude);
    }
}
