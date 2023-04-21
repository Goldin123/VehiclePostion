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
        public float RequestedLongitude { get; set; }
        public float RequestedLatitude { get; set; }
        public Int64 RecordedTimeUTC { get; set; }
        public double? Distance { get; set; }
        public float[] Point { get { return new[] { Latitude, Longitude }; } }
    }
}
