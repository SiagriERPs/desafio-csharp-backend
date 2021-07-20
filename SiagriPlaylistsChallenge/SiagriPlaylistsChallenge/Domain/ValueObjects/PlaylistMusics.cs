using SiagriPlaylistsChallenge.Domain.Contracts;
using SiagriPlaylistsChallenge.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.ValueObjects
{
    /// <summary>
    /// The main domain logic for the whole app architecture commes from this 
    /// object and because of that, most of the domain logic is self contain within
    /// this V.O
    /// </summary>
    /// <summary>
    /// Aqui é a lógica principal do serviço
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PlaylistMusics<T> : ValueObject<PlaylistMusics<T>>
    {
        public List<T> Value { get; set; }

        public IWeatherFinder<double> WeatherFinder { get; set; }

        /// <summary>
        /// Dentro do V.O decidi deixar o K como string, pois sabemos que 
        /// o parametro para achar a playlist vai ser um genero string
        /// </summary>
        public IPlaylistGenerator<T, string> Generator { get; }


        internal PlaylistMusics(List<T> value)
        {
            Value = value;
        }


        public static PlaylistMusics<T> CreatePlaylistFromCityName(string city, IWeatherFinder<double> weatherFinder, IPlaylistGenerator<T, string> generator)
        {
            double temperature = weatherFinder.GetWeatherData(city);
          

            string genre = CoolExaustiveSwitch(temperature);

            List<T> value = generator.GetPlaylistMusics(genre);

            return new PlaylistMusics<T>(value);
        }

       

        public static PlaylistMusics<T> CreatePlaylistFromLatAndLon(double latitude, double longitude, IWeatherFinder<double> weatherFinder, IPlaylistGenerator<T, string> generator)
        {
            double temperature = weatherFinder.GetWeatherData(latitude, longitude);
            

            string genre = CoolExaustiveSwitch(temperature);

            List<T> value = generator.GetPlaylistMusics(genre);

            return new PlaylistMusics<T>(value);

        }


        private static string CoolExaustiveSwitch(double value)
        {
            string resolve = value switch
            {
                > 30 => "Party",
                > 15 => "Pop",
                > 10 => "Rock",
                _ => "Classical",
            };

            return resolve;

        }

    }
}
