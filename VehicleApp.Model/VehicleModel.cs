using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.Model
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv {  get; set; }
    }
}
