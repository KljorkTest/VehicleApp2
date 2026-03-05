using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VehicleApp.DAL
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext() : base("name=VehicleConnectionString") 
        { }

        public DbSet<VehicleMakeEntity> VehicleMakes {  get; set; }
        public DbSet<VehicleModelEntity> VehicleModels { get; set; }
        public DbSet<UserVehicleEntity> UserVehicles { get; set; }
        public DbSet<UserEntity> Users {  get; set; }
    }
}
