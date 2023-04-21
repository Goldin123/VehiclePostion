using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePosition.Model;

namespace VehiclePosition.Data.Interface
{
    public interface IVehiclePostionData
    {
        Task<IList<Vehicle>> GetVehiclesAsync();
    }
}
