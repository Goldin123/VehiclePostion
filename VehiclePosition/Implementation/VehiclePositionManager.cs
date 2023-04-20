using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePosition.Interface;
using VehiclePosition.Service.Interface;

namespace VehiclePosition.Implementation
{
    public class VehiclePositionManager : IVehiclePositionManager
    {
        private readonly IVehicleService _vehicleService;

        public VehiclePositionManager(IVehicleService vehicleService) 
        {
            _vehicleService = vehicleService;
        }

        public async Task DoWork()
        {
            try
            {
                Console.WriteLine("Application Starting.....");
                var vehiclesData = await _vehicleService.GetVehiclesDataAsync();
                Console.WriteLine($"{vehiclesData.Item2}");
                if (vehiclesData.Item1?.Count() > 0)
                {
                    var vehicles = vehiclesData.Item1;
                    var requests = await _vehicleService.GenerateVehicleSearchRequestAsync();
                    if (requests.Item1?.Count() > 0)
                    {
                        Console.WriteLine($"{requests.Item2}\nPerforming Search......");
                        var performSearch = await _vehicleService.SearchWithKDTreeAsync(vehicles, requests.Item1);
                        Console.WriteLine($"{performSearch}");
                    }
                    else
                        Console.WriteLine("No Requests generated...");
                }
                Console.WriteLine("Application Stopping.....");
                Console.ReadLine();
                await Task.CompletedTask;
            }
            catch 
            {
                Console.WriteLine("Application is currently unavailable.....");
                await Task.CompletedTask;

            }
        }
    }
}
