using SiagriPlaylistsChallenge.Domain.Contracts;
using SiagriPlaylistsChallenge.Domain.Core;
using SiagriPlaylistsChallenge.Framework.Core;
using SiagriPlaylistsChallenge.Infrastructure.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.ValueObjects
{
    /// <summary>
    /// The main idea was to keep the domain logic self contained within
    /// the Value Objects and entities
    /// but I had a bit of a hard time with C# serialization and deserialization
    /// wich in the end made the concept a bit messy.
    /// bit with a bit of getting used to again with C# this could be reused
    /// </summary>
    public class PlaylistMusics : ValueObject<PlaylistMusics>
    {
        public PlaylistDTO Value { get; set; }

        public IWeatherFinder WeatherFinder { get; set; }

 
        public IPlaylistGenerator Generator { get; }


        internal PlaylistMusics(PlaylistDTO value)
        {
            Value = value;
        }


        public static PlaylistMusics CreatePlaylistFromCityName(string city, IWeatherFinder weatherFinder, IPlaylistGenerator generator)
        {
            var temperature = weatherFinder.GetWeatherData(city);
          

            string genre = CoolExaustiveSwitch(temperature.Temperature.Degree);

           

            PlaylistDTO value = generator.GetPlaylistMusics(genre);

            return new PlaylistMusics(value);
        }

       

        public static PlaylistMusics CreatePlaylistFromLatAndLon(double latitude, double longitude, IWeatherFinder weatherFinder, IPlaylistGenerator generator)
        {
            var temperature = weatherFinder.GetWeatherData(latitude, longitude);

            string genre = CoolExaustiveSwitch(temperature.Temperature.Degree);

            PlaylistDTO value = generator.GetPlaylistMusics(genre);

            return new PlaylistMusics(value);

        }


        public static string CoolExaustiveSwitch(double value)
        {
            string resolve = value switch
            {
                > 30 => "party",
                > 15 => "pop",
                > 10 => "rock",
                _ => "classical",
            };

            return resolve;

        }

    }
}
