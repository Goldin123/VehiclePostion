using KdTree;
using KdTree.Math;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePosition.Data.Interface;
using VehiclePosition.Model;
using VehiclePosition.Service.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VehiclePosition.Service.Implementation
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehiclePostionData _vehiclePostionData;
        private Stopwatch _stopwatch = new Stopwatch();
        public VehicleService(IVehiclePostionData vehiclePostionData ) 
        {
            _vehiclePostionData = vehiclePostionData;
        }

        public async Task<Tuple<IList<Vehicle>,string>> GetVehiclesDataAsync() 
        {
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                var data = await _vehiclePostionData.GetVehiclesAsync();
                _stopwatch.Stop();
                return new Tuple<IList<Vehicle>, string>(data, $"Fetched {data.Count} records in {_stopwatch.Elapsed.TotalSeconds} seconds.");
            }catch( Exception ex ) 
            {
                return new Tuple<IList<Vehicle>, string>(new List<Vehicle>(), ex.Message);

            }
        }

        public async Task<string> SearchWithKDTreeAsync(IList<Vehicle> vehicles, IList<VehicleSearchRequest> vehicleSearchRequests) 
        {
            var results = new StringBuilder();
            var vehicleTree = await SetVehicleTreeAync(vehicles);
            results.Append(vehicleTree.Item2);

            var perfomSerch = await PerformKDTreeSearch(vehicleTree.Item1, vehicleSearchRequests);
            results.Append($"\n{perfomSerch}");
            return results.ToString();;
        }

        async Task<Tuple<KdTree<float, Vehicle>,string>> SetVehicleTreeAync(IList<Vehicle> vehicles)
        {
            var tree = new KdTree.KdTree<float, Vehicle>(2, new FloatMath());
            try
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                Parallel.For(0, vehicles.Count, (i) =>
                {
                    var item = vehicles[i];
                    tree.Add(item.Point, item);
                });
                _stopwatch.Stop();
                return new Tuple<KdTree<float, Vehicle>, string>(tree, $"Setting vehicle tree took {_stopwatch.Elapsed.TotalSeconds} seconds.");
            }catch(Exception ex) 
            {
                return new Tuple<KdTree<float, Vehicle>, string>(tree, ex.Message);

            }
        }

        async Task<string> PerformKDTreeSearch(KdTree<float, Vehicle> tree, IList<VehicleSearchRequest> vehicleSearchRequests)
        {
            try 
            {
                 List<Vehicle> foundVehicles = new List<Vehicle>();
                _stopwatch.Reset();
                _stopwatch.Start();
                foreach (var  vehicleRequest in vehicleSearchRequests)
                {
                    var closest = tree.GetNearestNeighbours(new[] { vehicleRequest.Latutude, vehicleRequest.Latutude }, 1).FirstOrDefault();
                    if (closest != null)
                        foundVehicles.Add(closest.Value);
                }
                return $"Found {foundVehicles.Count} in {_stopwatch.Elapsed.TotalSeconds} seconds using KDTree.";

            }
            catch (Exception ex) { }
            return "";
        }
    }
}
