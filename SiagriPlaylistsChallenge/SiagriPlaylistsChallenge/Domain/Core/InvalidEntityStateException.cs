using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.Core
{
    public class InvalidEntityStateException : Exception
    {
        public InvalidEntityStateException(object entity, string message)
            : base($"Entity {entity.GetType().Name} state change rejected, {message}")
        {
        }
    }
}