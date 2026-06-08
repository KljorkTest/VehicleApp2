using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Common;
using VehicleApp.DAL;
using VehicleApp.Model;
using VehicleApp.Repository.Common;
using VehicleApp.Service.Common;

namespace VehicleApp.Service
{
    public class UserService : GenericService<UserEntity, User> , IUserService
    {
        private readonly IUnitOfWork _uow;

        protected override IGenericRepository<UserEntity> Repository => _uow.Users;

        public UserService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public async Task<IEnumerable<User>> GetAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting)
        {
            var entities = await _uow.Users.GetAsync(paging, filtering, sorting);
            return Mapper.Map<IEnumerable<User>>(entities);
        }
    }
}
