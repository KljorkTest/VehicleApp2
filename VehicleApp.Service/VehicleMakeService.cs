using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.DAL;
using VehicleApp.Model;
using VehicleApp.Service.Common;
using AutoMapper;
using VehicleApp.Repository.Common;
using VehicleApp.Model.Common;
using VehicleApp.Common;

namespace VehicleApp.Service
{
    public class VehicleMakeService :
        GenericService<VehicleMakeEntity, VehicleMake>, IVehicleMakeService
    {
        private readonly IUnitOfWork _uow;

        protected override IGenericRepository<VehicleMakeEntity> Repository => _uow.VehicleMakes;

        public VehicleMakeService(IUnitOfWork uow, IMapper mapper) :base(uow, mapper)
        {
        }

        public async Task<IEnumerable<VehicleMake>> GetAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting)
        {
            var entities = await _uow.VehicleMakes.GetAsync(paging, filtering, sorting);
            return Mapper.Map<IEnumerable<VehicleMake>>(entities);
        }
    }
}
