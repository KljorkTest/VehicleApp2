using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Common;
using VehicleApp.DAL;

namespace VehicleApp.Repository.Common
{
    public interface IVehicleMakeRepository : IGenericRepository<VehicleMakeEntity>
    {
        Task<IEnumerable<VehicleMakeEntity>> GetAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting);
    }
}
