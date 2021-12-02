using System.Collections.Generic;

namespace Microservice.Dtos
{
    public class MusicDto
    {
        public record Item(string name);
        public record Track(List<Item> items);

        public Track tracks { get; set; }
    }
}
