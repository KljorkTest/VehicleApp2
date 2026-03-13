using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Common;
using VehicleApp.DAL;
using VehicleApp.Repository.Common;
using System.Data.Entity;

namespace VehicleApp.Repository
{
    public class VehicleModelRepository : GenericRepository<VehicleModelEntity>, IVehicleModelRepository
    {
        public VehicleModelRepository(VehicleDbContext context) 
            : base(context) 
        { }

        public async Task<IEnumerable<VehicleModelEntity>> GetAsync(
            Guid? vehicleMakeId,
            Paging paging,
            Filtering filtering,
            Sorting sorting)
        {
            IQueryable<VehicleModelEntity> query = _dbSet.Include(x => x.VehicleMake);

            if (vehicleMakeId.HasValue)
            {
                query = query.Where(x => x.VehicleMakeId == vehicleMakeId.Value);
            }
        }
    }
}
