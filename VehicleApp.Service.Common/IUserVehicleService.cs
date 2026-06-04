using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Model;
using VehicleApp.Common;
using VehicleApp.Model.Common;

namespace VehicleApp.Service.Common
{
    public interface IUserVehicleService
    {
        Task<IEnumerable<UserVehicle>> GetByUserIdAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting,
            Guid userId);

        Task<UserVehicle> GetByIdAsync(Guid userId, Guid id);
        Task CreateAsync(Guid userId, Guid vehicleModelId);
        Task UpdateAsync(Guid userId, Guid id, Guid vehicleModelId);
        Task DeleteAsync(Guid id);

    }
}
