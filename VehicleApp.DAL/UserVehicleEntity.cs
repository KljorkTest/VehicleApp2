using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.DAL
{
    public class UserVehicleEntity
    {
        public Guid Id {  get; set; }
        public Guid UserId { get; set; }
        public Guid VehicleModelId { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual VehicleModelEntity VehicleModel { get; set; }
        public virtual UserEntity User {  get; set; }

        public UserVehicleEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
