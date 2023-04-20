using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePosition.Model
{
    public class VehicleSearchRequest
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public float[] Point { get { return new[] { Latitude, Longitude }; } }

        public VehicleSearchRequest( float longitude , float latitude) 
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
