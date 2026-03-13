using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.DAL;
using VehicleApp.Repository.Common;
using VehicleApp.Common;
using System.Data.Entity;

namespace VehicleApp.Repository
{
    public class VehicleMakeRepository : GenericRepository<VehicleMakeEntity>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(VehicleDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<VehicleMakeEntity>> GetAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting)
        {
            IQueryable<VehicleMakeEntity> query = _dbSet;

            if (filtering != null && !string.IsNullOrEmpty(filtering.Search))
            {
                query = query.Where(x => x.Name.Contains(filtering.Search) || x.Abrv.Contains(filtering.Search));
            }

            if (sorting != null && !string.IsNullOrEmpty(sorting.SortBy))
            {
                if (sorting.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    query = sorting.IsDescending ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);

                if (sorting.SortBy.Equals("Abrv", StringComparison.OrdinalIgnoreCase))
                    query = sorting.IsDescending ? query.OrderByDescending(x => x.Abrv) : query.OrderBy(x => x.Abrv);
            }
            else
            {
                query = query.OrderBy(x => x.Name);
            }

            query = query
                .Skip((paging.Page -1)  * paging.PageSize)
                .Take(paging.PageSize);

            return await query.ToListAsync();
        }
    }
}
