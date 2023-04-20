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
        public float Latutude { get; set; }
        public VehicleSearchRequest( float longitude , float latitude) 
        {
            Longitude = longitude;
            Latutude = latitude;
        }
    }
}
