using SiagriPlaylistsChallenge.Domain.Core;
using SiagriPlaylistsChallenge.Domain.ValueObjects;
using SiagriPlaylistsChallenge.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.Entities
{
    public class Playlist : Entity<PlaylistId>
    {
        public PlaylistId Id { get; private set; }
        public PlaylistMusics<Music> Musics { get; private set; }

        public PlaylistState State { get; private set; }




        public Playlist(PlaylistId id, PlaylistMusics<Music> musics, object weatherData)
        {
            Id = id;
            Musics = musics;

        }

        public Playlist(PlaylistId id) =>
           Apply(new Events.PlaylistCreated {
               Id = id,
           });


        public void UpdateMusics(PlaylistMusics<Music> musics) =>
            Apply(new Events.PlaylistMusicsUpdated
            {
                Id = Id,
                Musics = convertToStringList(musics.Value)
            });

        public void ResquestPlaylist() =>
            Apply(new Events.PlaylistReadyToBeShown { Id = Id });


        /// <summary>
        /// Use C# advanced pattern matching to manage state change 
        /// 
        /// </summary>
        /// <param name="event"></param>
        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.PlaylistCreated e:
                    Id = new PlaylistId(e.Id);
                    State = PlaylistState.Creating;
                    break;
                case Events.PlaylistMusicsUpdated e:
                    Musics = new PlaylistMusics<Music>(ConvertToMusicList(e.Musics));
                    break;
                case Events.PlaylistReadyToBeShown _:
                    State = PlaylistState.Ready;
                    break;
            }
        }

        public static List<Music> ConvertToMusicList(List<string> list)
        {
            List<Music> parsedList = new List<Music>() { };
            foreach (string music in list)
            {
                parsedList.Add(new Music { Name = music });
            }

            return parsedList;

        }

        /// <summary>
        /// Method to convert a list of Music value objects to 
        /// a string list. The implicit operator can do the same
        /// but this is a bit more readable and explicit (heh)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<string> convertToStringList(List<Music> list)
        {
            List<string> parsedList = new List<string>() { };
            foreach(Music music in list)
            {
                parsedList.Add(music.Name);
            }

            return parsedList;
        }




        public enum PlaylistState
        {
            Creating,
            Ready
        }

      

        protected override void EnsureValidState()
        {
            var valid =
                Id != null &&
                (State switch
                {
                    PlaylistState.Creating =>
                        Id != null,
                    PlaylistState.Ready =>
                        Musics != null,
                    _ => true
                }) ;

            if (!valid)
                throw new InvalidEntityStateException(this, $"State validity check in state {State}"); ;
        }
    }
}
