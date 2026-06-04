using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Common;
using VehicleApp.Model;

namespace VehicleApp.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting,
            Guid makeId);

        Task<VehicleModel> GetByIdAsync(Guid id);
        Task CreateAsync(VehicleModel model);
        Task UpdateAsync(Guid id, VehicleModel model);
        Task DeleteAsync(Guid id);
    }
}
