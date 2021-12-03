using Microservice.Dtos;
using Microservice.Helpers.Enums;
using Microservice.Helpers.Extensions;
using Microservice.Repositories;
using Microservice.Responses;
using Microservice.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Tests
{
    [TestClass]
    public class MusicTests
    {
        private Mock<IMusicRepository> _mockRepository;
        private IMusicService _musicService;

        private MusicDto.Item item = new("Testing");

        public MusicTests()
        {
            _mockRepository = new Mock<IMusicRepository>();
            _mockRepository.Setup(repo => repo.GetMusicsByGenre(EMusicGenre.Party.GetDescription()))
                   .ReturnsAsync(new Response<MusicDto>()
                   {
                       Data = new MusicDto
                       {
                           tracks = new MusicDto.Track(new List<MusicDto.Item> { item, item }),
                       },
                       StatusCode = 200,
                       Error = null
                   });
            _mockRepository.Setup(repo => repo.GetMusicsByGenre(EMusicGenre.Pop.GetDescription()))
                .ReturnsAsync(new Response<MusicDto>()
                {
                    Data = new MusicDto
                    {
                        tracks = new MusicDto.Track(new List<MusicDto.Item> { item, item, item, item, item, item }),
                    },
                    StatusCode = 200,
                    Error = null
                });
            _mockRepository.Setup(repo => repo.GetMusicsByGenre(EMusicGenre.Rock.GetDescription()))
                   .ReturnsAsync(new Response<MusicDto>()
                   {
                       Data = new MusicDto
                       {
                           tracks = new MusicDto.Track(new List<MusicDto.Item> { item, item, item, item, item, item, item, item, item, item }),
                       },
                       StatusCode = 200,
                       Error = null
                   });
            _mockRepository.Setup(repo => repo.GetMusicsByGenre(EMusicGenre.Classical.GetDescription()))
                .ReturnsAsync(new Response<MusicDto>()
                {
                    Data = new MusicDto
                    {
                        tracks = new MusicDto.Track(new List<MusicDto.Item> { item }),
                    },
                    StatusCode = 200,
                    Error = null
                });
        }

        [TestMethod]
        public async Task Should_Count_2_When_Temperature_Is_33()
        {
            _musicService = new MusicService(_mockRepository.Object);

            var response = await _musicService.GetMusicsByTemperature(33);

            Assert.AreEqual(response.Data.tracks.items.Count(), 2);
        }

        [TestMethod]
        public async Task Should_Count_6_When_Temperature_Is_30()
        {
            _musicService = new MusicService(_mockRepository.Object);

            var response = await _musicService.GetMusicsByTemperature(30);

            Assert.AreEqual(response.Data.tracks.items.Count(), 6);
        }


        [TestMethod]
        public async Task Should_Count_10_When_Temperature_Is_10()
        {
            _musicService = new MusicService(_mockRepository.Object);

            var response = await _musicService.GetMusicsByTemperature(10);

            Assert.AreEqual(response.Data.tracks.items.Count(), 10);
        }

        [TestMethod]
        public async Task Should_Count_1_When_Temperature_Is_2()
        {
            _musicService = new MusicService(_mockRepository.Object);

            var response = await _musicService.GetMusicsByTemperature(2);

            Assert.AreEqual(response.Data.tracks.items.Count(), 1);
        }
    }
}
