using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePosition.Data.Interface;
using VehiclePosition.Model;
using static System.Net.Mime.MediaTypeNames;

namespace VehiclePosition.Data.Implementation
{
    public class VehiclePostionData : IVehiclePostionData
    {
        private readonly string _dataFilePath = $"{Path.GetFullPath(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"../../../../"))}{ConfigurationManager.AppSettings["FileName"]}";
        private readonly long _maxRecords = Convert.ToInt64(ConfigurationManager.AppSettings["MaxRecords"]);
        public Task<IList<Vehicle>> GetVehiclesAsync()
        {
            var list = new List<Vehicle>();
            try
            {
                if (!File.Exists(_dataFilePath))
                    return Task.FromResult<IList<Vehicle>>(list);

                using (var stream = new FileStream(_dataFilePath, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        for (int i = 0; i < _maxRecords; i++)
                        {
                            var item = new Vehicle
                            {
                                PositionId = reader.ReadInt32(),
                                VehicleRegistration = GetNullTerminatedString(reader),                               
                                Latitude = reader.ReadSingle(),
                                Longitude = reader.ReadSingle(),
                                RecordedTimeUTC = reader.ReadInt64()
                            };
                            list.Add(item);
                        }
                    }
                }
                list = list.OrderBy(a=>a.Latitude).ToList();
                return Task.FromResult<IList<Vehicle>>(list);
            }
            catch
            {
                return Task.FromResult<IList<Vehicle>>(list);
            }
        }
        string GetNullTerminatedString(BinaryReader reader)
        {
            var sb = new System.Text.StringBuilder();
            int nc;
            while ((nc = reader.Read()) > 0)
                sb.Append((char)nc);

            return sb.ToString();
        }
    }
}
