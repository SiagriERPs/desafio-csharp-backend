
using SiagriPlaylistsChallenge.Domain.Core;
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
        public void Should_create_a_valid_playlist_using_city_name()
        {
            _playlist.UpdateMusics(PlaylistMusics<Music>.CreatePlaylistFromCityName("Goiânia",  new FakeWeatherFinder(), new FakePlaylistGenerator()));


            _playlist.ResquestPlaylist();


            Assert.Equal(Playlist.PlaylistState.Ready, _playlist.State);

        }
        [Fact]
        public void Should_create_a_valid_playlist_with_4_musics()
        {
            _playlist.UpdateMusics(PlaylistMusics<Music>.CreatePlaylistFromCityName("Cidade Pop", new FakeWeatherFinder(), new FakePlaylistGenerator()));

            _playlist.ResquestPlaylist();

            Assert.Equal(4, _playlist.Musics.Value.Count);
        }




        [Fact]
        public void Should_create_a_valid_playlist_using_valid_lat_lon_combination()
        {
            _playlist.UpdateMusics(PlaylistMusics<Music>.CreatePlaylistFromLatAndLon(-16.67, -49.25, new FakeWeatherFinder(), new FakePlaylistGenerator()));


            _playlist.ResquestPlaylist();


            Assert.Equal(Playlist.PlaylistState.Ready, _playlist.State);

        }

        [Fact]
        public void Should_create_a_valid_playlist_with_2_musics()
        {
            _playlist.UpdateMusics(PlaylistMusics<Music>.CreatePlaylistFromCityName("Cidade Rock", new FakeWeatherFinder(), new FakePlaylistGenerator()));


            _playlist.ResquestPlaylist();

            Assert.Equal(2, _playlist.Musics.Value.Count);
        }
        [Fact]
        public void Should_not_create_playlist_without_musics()
        {
           

            Assert.Throws<InvalidEntityStateException>(() => _playlist.ResquestPlaylist());
        }

    }
}
