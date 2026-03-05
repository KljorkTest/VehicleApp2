using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.DAL
{
    public class VehicleMakeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv {  get; set; }
        public virtual ICollection<VehicleModelEntity> Models {  get; set; }

        public VehicleMakeEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
