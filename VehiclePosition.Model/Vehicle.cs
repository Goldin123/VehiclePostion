using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePosition.Model
{
    public class Vehicle
    {
        public int PositionId { get; set; }
        public string? VehicleRegistration { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public long RecordedTimeUTC { get; set; }
        public float[] Point { get { return new[] { Latitude, Longitude }; } }
    }
}
