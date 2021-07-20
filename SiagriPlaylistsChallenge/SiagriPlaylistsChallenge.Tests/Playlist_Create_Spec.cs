
using SiagriPlaylistsChallenge.Domain.Entities;
using SiagriPlaylistsChallenge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using Xunit;


namespace SiagriPlaylistsChallenge.Tests
{
    public class Playlist_Create_Spec
    {
        private readonly Playlist _playlist;

        //Basic DI 
        public Playlist_Create_Spec()
        {
            _playlist = new Playlist(
                new PlaylistId(Guid.NewGuid()));
        }

        [Fact]
        public void Can_create_valid_playlist()
        {
            _playlist.UpdateMusics(PlaylistMusics<Music>.CreatePlaylistFromCityName("Goiânia",  new FakeWeatherFinder(), new FakePlaylistGenerator()));


            _playlist.ResquestPlaylist();


            Assert.Equal(Playlist.PlaylistState.Ready, _playlist.State);

        }

    }
}
