using SiagriPlaylistsChallenge.Framework.Core;
using System;


namespace SiagriPlaylistsChallenge.Domain.ValueObjects
{
    public class PlaylistId : IEquatable<PlaylistId>
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

        public bool Equals(PlaylistId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PlaylistId)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
