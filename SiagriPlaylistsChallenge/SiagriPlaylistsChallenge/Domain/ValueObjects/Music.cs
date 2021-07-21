using Newtonsoft.Json;
using SiagriPlaylistsChallenge.Framework.Core;


namespace SiagriPlaylistsChallenge.Domain.ValueObjects
{
    public class Music : ValueObject<Music>
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
    }
}
