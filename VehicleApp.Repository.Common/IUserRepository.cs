using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Common;
using VehicleApp.DAL;

namespace VehicleApp.Repository.Common
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        Task<IEnumerable<UserEntity>> GetAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting);
    }
}
