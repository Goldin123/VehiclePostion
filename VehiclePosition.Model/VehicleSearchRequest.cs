using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePosition.Model
{
    public class VehicleSearchRequest
    {
        
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public float[] Point { get { return new[] {  Latitude, Longitude }; } }

        public VehicleSearchRequest(  float latitude, float longitude) 
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
