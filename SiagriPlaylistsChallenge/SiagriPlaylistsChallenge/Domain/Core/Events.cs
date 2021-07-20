using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.Core
{
    /// <summary>
    /// This is the events that will be used in the observer pattern and will be 
    /// watched with the entity When method
    /// </summary>
    /// <summary>
    /// Extremament overkill em uma aplicação dessa simplicidade de especificações
    /// porém bastante util e acompanha bem a escalonabilidade do serviço
    /// </summary>
    public static class Events
    {
        public class PlaylistCreated
        {
            public Guid Id { get; set; }
        }

        public class PlaylistMusicsUpdated
        {
            public Guid Id { get; set; }
            public List<string> Musics { get; set; }
        }

        public class PlaylistReadyToBeShown
        {
            public Guid Id { get; set; }
        }
    }
}
