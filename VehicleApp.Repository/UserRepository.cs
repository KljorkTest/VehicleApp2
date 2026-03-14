using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Common;
using VehicleApp.DAL;
using VehicleApp.Repository.Common;
using VehicleApp.Common.Exceptions;

namespace VehicleApp.Repository
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(VehicleDbContext context) 
            : base(context) 
        { }

        public async Task<IEnumerable<UserEntity>> GetAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting)
        {
            IQueryable<UserEntity> query = _dbSet;

            if (filtering != null && !string.IsNullOrWhiteSpace(filtering.Search))
            {
                query = query.Where(x => x.UserName.Contains(filtering.Search));
            }

            if (sorting != null && !string.IsNullOrWhiteSpace(sorting.SortBy))
            {
                if (sorting.SortBy.Equals("Username", StringComparison.OrdinalIgnoreCase))
                {
                    query = sorting.IsDescending 
                        ? query.OrderByDescending(x => x.UserName) 
                        : query.OrderBy(x => x.UserName);
                }
            }
            else
            {
                query = query.OrderBy(x => x.UserName);
            }

            if (paging != null)
            {
                query = query
                    .Skip((paging.Page - 1) * paging.PageSize)
                    .Take(paging.PageSize);
            }

            try
            {
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Failed to load users!", ex);
            }
        }
    }
}
