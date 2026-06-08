using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Service.Common;
using VehicleApp.Repository.Common;
using AutoMapper;
using VehicleApp.Common;
using VehicleApp.Common.Exceptions;
using VehicleApp.Model;
using VehicleApp.DAL;



namespace VehicleApp.Service
{
    public class UserVehicleService : IUserVehicleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserVehicleService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserVehicle>> GetByUserIdAsync(
            Paging paging,
            Filtering filtering,
            Sorting sorting,
            Guid userId)
        {
            try
            {
                var entities = await _uow.UserVehicles.GetByUserIdAsync(paging, filtering, sorting, userId);
                return _mapper.Map<IEnumerable<UserVehicle>>(entities);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to load user vehicles!", ex);
            }
        }

        public async Task<UserVehicle> GetByIdAsync(Guid userId, Guid id)
        {
            var entity = await _uow.UserVehicles.GetByIdAsync(id);
            if (entity == null || entity.UserId != userId)
                throw new BusinessException("The user does not have that vehicle model!");
            
            return _mapper.Map<UserVehicle>(entity);
        }

        public async Task CreateAsync(Guid userId, Guid vehicleModelId)
        {
            var modelExists = await _uow.VehicleModels.GetByIdAsync(vehicleModelId);
            if (modelExists == null)
                throw new BusinessException("Vehicle model doe snot exist!");

            var entity = new UserVehicleEntity
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                VehicleModelId = vehicleModelId,
                DateAdded = DateTime.UtcNow
            };

            try
            {
                await _uow.UserVehicles.CreateAsync(entity);
                await _uow.SaveAsync();
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to add vehicle to user!", ex);
            }
        }

        public async Task UpdateAsync(Guid userId, Guid id, Guid vehicleModelId)
        {
            var entity = await _uow.UserVehicles.GetByIdAsync(id);
            if (entity == null)
                throw new BusinessException("User vehicle not found!");

            if (entity.UserId != userId)
                throw new BusinessException("You are not allowed to modify this vehicle!");

            entity.VehicleModelId = vehicleModelId;
            try
            {
                await _uow.UserVehicles.UpdateAsync(entity);
                await _uow.SaveAsync();
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to update user vehicle!", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _uow.UserVehicles.GetByIdAsync(id);
            if (entity == null)
                throw new BusinessException("User vehicle not found!");

            try
            {
                await _uow.UserVehicles.DeleteAsync(id);
                await _uow.SaveAsync();
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to delete user vehicle", ex);
            }
        }
    }
}
