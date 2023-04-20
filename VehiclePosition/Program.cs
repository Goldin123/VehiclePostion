// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehiclePosition.Implementation;
using VehiclePosition.Interface;

namespace VehiclePosition 
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                             .ConfigureServices(services =>
                                  {
                                    services.AddSingleton<IVehiclePosition, VehiclePositionApp>();
                                   }
                                  ).Build();

            var vehiclePos = host.Services.GetService<IVehiclePosition>();
            await vehiclePos.DoWork();
            await host.RunAsync();
        }
    }
}