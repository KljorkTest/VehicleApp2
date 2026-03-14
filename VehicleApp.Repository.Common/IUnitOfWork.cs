using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleMakeRepository VehicleMakes {  get; }
        IVehicleModelRepository VehicleModels { get; }
        IUserVehicleRepository UserVehicles { get; }
        IUserRepository Users { get; }

        Task SaveAsync();
    }
}
