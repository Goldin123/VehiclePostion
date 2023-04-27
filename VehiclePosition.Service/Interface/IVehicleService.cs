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
        Task<string> SearchWithKDTreeAsync(IList<Vehicle> vehicles, IList<VehicleSearchRequest> vehicleSearchRequests);
        Task<Tuple<IList<VehicleSearchRequest>,string>> GenerateVehicleSearchRequestAsync();
        Task<string> PerformSearchHaversineFormulaAsync(IList<Vehicle> vehicles, IList<VehicleSearchRequest> vehicleSearchRequests);
        Task<string> CustomNearestVehiclePositions(IList<Vehicle> vehicles, IList<VehicleSearchRequest> vehicleSearchRequests);
    }
}
