using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.DAL;
using VehicleApp.Service.Common;
using VehicleApp.Model;
using AutoMapper;
using VehicleApp.Common.Exceptions;
using VehicleApp.Repository.Common;
using VehicleApp.Common;


namespace VehicleApp.Service
{
    public class VehicleModelService : GenericService<VehicleModelEntity, VehicleModel> ,IVehicleModelService
    {
        private readonly IUnitOfWork _uow;

        protected override IGenericRepository<VehicleModelEntity> Repository => _uow.VehicleModels;

        public VehicleModelService(
            IUnitOfWork uow,
            IMapper mapper) :base(uow, mapper)
        {
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting,
            Guid makeId)
        {
            var entities = await _uow.VehicleModels.GetAsync(paging, filtering, sorting, makeId);

            return Mapper.Map<IEnumerable<VehicleModel>>(entities);
        }

        public override async Task CreateAsync(VehicleModel model)
        {
            var make = await _uow.VehicleMakes.GetByIdAsync(model.VehicleMakeId);
            if (make == null)
                throw new BusinessException("Vehicle make does not exist!");
            try
            {
                await base.CreateAsync(model);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to create vehicle model!", ex);
            }
        }

        public override async Task UpdateAsync(Guid id, VehicleModel model)
        {
            var entity = await _uow.VehicleModels.GetByIdAsync(id);
            if (entity == null)
                throw new BusinessException("Vehicle model not found!");

            entity.Name = model.Name;
            entity.Abrv = model.Abrv;

            try
            {
                await _uow.SaveAsync();
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to pdate vehicle model!", ex);
            }
        }
    }
}
