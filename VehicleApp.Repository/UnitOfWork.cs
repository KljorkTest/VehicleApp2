using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.DAL;
using VehicleApp.Repository.Common;

namespace VehicleApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleDbContext _context;

        public IVehicleMakeRepository VehicleMakes { get; }
        public IVehicleModelRepository VehicleModels {  get; }
        public IUserVehicleRepository UserVehicles { get; }
        public IUserRepository Users { get; }

        public UnitOfWork (VehicleDbContext context)
        {
            _context = context;

            VehicleMakes = new VehicleMakeRepository(_context);
            VehicleModels = new VehicleModelRepository(_context);
            UserVehicles = new UserVehicleRepository(_context);
            Users = new UserRepository(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
