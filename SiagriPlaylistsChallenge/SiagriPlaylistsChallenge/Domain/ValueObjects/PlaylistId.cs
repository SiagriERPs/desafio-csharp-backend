using SiagriPlaylistsChallenge.Framework.Core;
using System;


namespace SiagriPlaylistsChallenge.Domain.ValueObjects
{
    public class PlaylistId : ValueObject<PlaylistId>
    {
        private Guid Value { get; set; }

        public PlaylistId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Playlist Id cannot be empty");
        }

        public static implicit operator Guid(PlaylistId self) => self.Value;

        public static implicit operator PlaylistId(string value)
            => new PlaylistId(Guid.Parse(value));
    }
}
