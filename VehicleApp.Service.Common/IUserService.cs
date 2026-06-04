using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Model;
using VehicleApp.Model.Common;
using VehicleApp.Common;

namespace VehicleApp.Service.Common
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting);

        Task<User> GetByIdAsync(Guid id);
        Task CreateAsync(User model);
        Task UpdateAsync(Guid id, User model);
        Task DeleteAsync(Guid id);

    }
}
