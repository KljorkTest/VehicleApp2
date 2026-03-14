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
    public class UserVehicleRepository : GenericRepository<UserVehicleEntity>, IUserVehicleRepository
    {
        public UserVehicleRepository(VehicleDbContext context) 
            : base(context) 
        { }

        public async Task<IEnumerable<UserVehicleEntity>> GetByUserIdAsync(
            Guid userId,
            Paging paging,
            Filtering filtering,
            Sorting sorting)
        {
            IQueryable<UserVehicleEntity> query = _dbSet
                .Include(x => x.VehicleModel)
                .Include(x => x.VehicleModel.VehicleMake)
                .Where(x => x.UserId == userId);

            if (filtering != null && !string.IsNullOrWhiteSpace(filtering.Search))
            {
                query = query.Where(x =>
                x.VehicleModel.Name.Contains(filtering.Search) ||
                x.VehicleModel.VehicleMake.Name.Contains(filtering.Search));
            }

            if (sorting != null && !string.IsNullOrWhiteSpace(sorting.SortBy))
            {
                if (sorting.SortBy.Equals("DateAdded", StringComparison.OrdinalIgnoreCase))
                {
                    query = sorting.IsDescending 
                        ? query.OrderByDescending(x => x.DateAdded) 
                        : query.OrderBy(x => x.DateAdded);
                }
                else if (sorting.SortBy.Equals("Model", StringComparison.OrdinalIgnoreCase))
                {
                    query = sorting.IsDescending
                        ? query.OrderByDescending(x => x.VehicleModel.Name)
                        : query.OrderBy(x => x.VehicleModel.Name);
                }
                else if (sorting.SortBy.Equals("Make", StringComparison.OrdinalIgnoreCase))
                {
                    query = sorting.IsDescending
                        ? query.OrderByDescending(x => x.VehicleModel.VehicleMake.Name)
                        : query.OrderBy(x => x.VehicleModel.VehicleMake.Name);
                }
            }
            else
            {
                query = query.OrderByDescending(x => x.DateAdded);
            }

            query = query
                .Skip((paging.Page - 1) * paging.PageSize)
                .Take((paging.PageSize));

            try
            {
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to load user vehicles!", ex);
            }
        }
    }
}
