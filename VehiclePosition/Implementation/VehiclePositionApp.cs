using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePosition.Interface;

namespace VehiclePosition.Implementation
{
    public class VehiclePositionApp : IVehiclePosition
    {
        public Task DoWork()
        {
            Console.WriteLine("Hello, World!");
            Console.ReadLine();
            return Task.CompletedTask;
        }
    }
}
