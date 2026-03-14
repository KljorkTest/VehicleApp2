using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Common;
using VehicleApp.DAL;
using VehicleApp.Repository.Common;
using System.Data.Entity;
using VehicleApp.Common.Exceptions;

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

            if (filtering != null && !string.IsNullOrEmpty(filtering.Search))
            {
                query = query.Where(x => x.Name.Contains(filtering.Search) || x.VehicleMake.Name.Contains(filtering.Search));
            }

            if (sorting != null && !string.IsNullOrEmpty(sorting.SortBy))
            {
                if (sorting.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    query = sorting.IsDescending ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);

                if (sorting.SortBy.Equals("Make", StringComparison.OrdinalIgnoreCase))
                    query = sorting.IsDescending ? query.OrderByDescending(x => x.VehicleMake.Name) 
                        : query.OrderBy(x => x.VehicleMake.Name);
            }

            else
            {
                query = query.OrderBy(x => x.Name);
            }

            query = query
                .Skip((paging.Page - 1) * paging.PageSize)
                .Take(paging.PageSize);

            try
            {
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to load vehicle models!", ex);
            }
        }
    }
}
