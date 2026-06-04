using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Common;
using VehicleApp.Model;
using VehicleApp.Model.Common;

namespace VehicleApp.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> GetAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting);

        Task<VehicleMake> GetByIdAsync(Guid id);
        Task CreateAsync(VehicleMake model);
        Task UpdateAsync(Guid id, VehicleMake model);
        Task DeleteAsync(Guid id);
    }
}
