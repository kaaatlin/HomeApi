using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Models.Devices
{
    public class DeleteDeviceRequest
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int CurrentVolts { get; set; }
        public bool GasUsage { get; set; }
        public string RoomLocation { get; set; }
    }
}
