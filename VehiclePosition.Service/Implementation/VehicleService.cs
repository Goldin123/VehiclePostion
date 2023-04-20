using System;
using System.Collections.Generic;
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

        public async Task<IList<Vehicle>> GetVehiclesData() 
        {
            return await _vehiclePostionData.GetVehicles();
        }
    }
}
