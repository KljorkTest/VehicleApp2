using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.DAL
{
    public class VehicleModelEntity
    {
        public Guid Id { get; set; }
        public string VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual VehicleMakeEntity Make {  get; set; }
        
        public VehicleModelEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
