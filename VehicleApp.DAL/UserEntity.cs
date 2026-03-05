using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.DAL
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<UserVehicleEntity> UserVehicles {  get; set; }
        public UserEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
