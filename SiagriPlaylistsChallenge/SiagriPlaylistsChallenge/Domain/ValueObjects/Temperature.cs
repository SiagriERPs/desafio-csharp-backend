using SiagriPlaylistsChallenge.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiagriPlaylistsChallenge.Domain.ValueObjects
{
    public class Temperature : ValueObject<Temperature>
    {
        public string City { get; set; }

        // Validade para ter algum valor no qual eu possa usar para não ter que lidar com null checks
        public bool Valid { get; set; }
        public double Latitude { get; set; }
        public double Longitute { get; set; }
        public double Value { get; set; }





    }
}
