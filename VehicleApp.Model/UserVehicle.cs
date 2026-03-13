using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.Model
{
    public class UserVehicle
    {
        public Guid Id { get; set; }
        public Guid VehicleModelId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
