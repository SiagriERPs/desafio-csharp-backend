using System.ComponentModel;

namespace Microservice.Helpers.Enums
{
    public enum EMusicGenre
    {
        [Description("party")]
        Party,
        [Description("pop")]
        Pop,
        [Description("rock")]
        Rock,
        [Description("classical")]
        Classical
    }
}
