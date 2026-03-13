using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Model.Common;

namespace VehicleApp.Model
{
    public class UserVehicle : IUserVehicle
    {
        public Guid Id { get; set; }
        public Guid VehicleModelId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
