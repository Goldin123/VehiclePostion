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
        private readonly string dataFilePath = $"{Path.GetFullPath(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"../../../../"))}VehiclePosition.Data\\Data\\{ConfigurationManager.AppSettings["FileName"]}";
        private const long maxRecords = 2000000;
        public Task<IList<Vehicle>> GetVehiclesAsync()
        {

            var list = new List<Vehicle>();
            try
            {
                if (!File.Exists(dataFilePath))
                    return Task.FromResult<IList<Vehicle>>(list);

                using (var stream = new FileStream(dataFilePath, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        for (int i = 0; i < maxRecords; i++)
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
