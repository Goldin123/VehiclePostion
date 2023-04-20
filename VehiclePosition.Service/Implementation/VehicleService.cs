using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePosition.Data.Interface;
using VehiclePosition.Model;
using VehiclePosition.Service.Interface;

namespace VehiclePosition.Service.Implementation
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehiclePostionData _vehiclePostionData;
        public VehicleService(IVehiclePostionData vehiclePostionData ) 
        {
            _vehiclePostionData = vehiclePostionData;
        }

        public async Task<Tuple<IList<Vehicle>,string>> GetVehiclesData() 
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var data = await _vehiclePostionData.GetVehicles();
            sw.Stop();
            return new Tuple<IList<Vehicle>, string>(data,$"Fetched {data.Count} records in {sw.Elapsed.TotalSeconds} seconds.");
        }
    }
}
