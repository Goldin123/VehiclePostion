// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehiclePosition.Data.Implementation;
using VehiclePosition.Data.Interface;
using VehiclePosition.Implementation;
using VehiclePosition.Interface;
using VehiclePosition.Service.Implementation;
using VehiclePosition.Service.Interface;


try
{
    using IHost host = Host.CreateDefaultBuilder(args)
                                 .ConfigureServices(services =>
                                      {
                                          _ = services.AddSingleton<IVehiclePositionManager, VehiclePositionManager>();
                                          _ = services.AddSingleton<IVehicleService, VehicleService>();
                                          _ = services.AddSingleton<IVehiclePostionData, VehiclePostionData>();
                                      }
                                      ).Build();

   var vehiclePos = host.Services.GetService<IVehiclePositionManager>();

    if (vehiclePos != null)
        await vehiclePos.DoWork();

    await host.RunAsync();
    Environment.Exit(0);

}
catch
{
}