using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePosition.Data.Interface;
using VehiclePosition.Model;

namespace VehiclePosition.Data.Implementation
{
    public class VehiclePostionData : IVehiclePostionData
    {

        public Task<IList<Vehicle>> GetVehicles()
        {
            var list = new List<Vehicle>();
            try
            {
                return Task.FromResult<IList<Vehicle>>(list);
            }
            catch 
            {
                return Task.FromResult<IList<Vehicle>>(list);
            }
        }
    }
}
