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
            Console.WriteLine("Application Starting.....");
            var vehiclesData = await _vehicleService.GetVehiclesData();
            Console.WriteLine($"{vehiclesData.Item2}");
            Console.WriteLine("Application Stopping.....");
            Console.ReadLine();
            await Task.CompletedTask;
        }
    }
}
