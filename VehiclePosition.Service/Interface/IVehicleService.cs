using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePosition.Model;

namespace VehiclePosition.Service.Interface
{
    public interface IVehicleService
    {
        Task<Tuple<IList<Vehicle>, string>> GetVehiclesDataAsync(); 
    }
}
