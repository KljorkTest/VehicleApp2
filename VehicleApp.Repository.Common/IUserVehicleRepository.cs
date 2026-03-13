using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Common;
using VehicleApp.DAL;

namespace VehicleApp.Repository.Common
{
    public interface IUserVehicleRepository : IGenericRepository<UserVehicleEntity>
    {
        Task<IEnumerable<UserVehicleEntity>> GetByUserIdAsync(
            Guid userId,
            Paging paging,
            Filtering filtering,
            Sorting sorting);
    }
}
