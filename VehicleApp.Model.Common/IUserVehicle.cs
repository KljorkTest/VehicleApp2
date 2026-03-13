using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.Model.Common
{
    public interface IUserVehicle
    {
        Guid Id { get; set; }
        Guid VehicleModelId { get; set; }
        DateTime DateAdded { get; set; }
    }
}
