using MusicSuggestorAPI.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSuggestorAPI.Domain.Common
{
    public static class MusicTypeResolver
    {
        public static eMusicType GetMusicTypeBy(double temperature)
        {
            if (temperature > 30)
                return eMusicType.party;
            else if (temperature <= 30 && temperature >= 15)
                return eMusicType.pop;
            else if (temperature <= 14 && temperature >= 10)
                return eMusicType.rock;
            else 
                return eMusicType.classical;
        }

    }
}
