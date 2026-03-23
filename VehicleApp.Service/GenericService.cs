using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VehicleApp.Repository.Common;
using VehicleApp.Common.Exceptions;
using System.Runtime.CompilerServices;

namespace VehicleApp.Service
{
    public abstract class GenericService<TEntity, TModel>
        where TEntity : class
    {
        protected readonly IUnitOfWork UoW;
        protected readonly IMapper Mapper;

        protected abstract IGenericRepository<TEntity> Repository { get; }
        protected GenericService(IUnitOfWork uoW, IMapper mapper)
        {
            UoW = uoW;
            Mapper = mapper;
        }

        public virtual async Task<TModel> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await Repository.GetByIdAsync(id);
                if (entity == null)
                    throw new BusinessException("Entity not found!");

                return Mapper.Map<TModel>(entity);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to load entity!", ex);
            }
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            try
            {
                var entities = await Repository.GetAllAsync();
                return Mapper.Map<IEnumerable<TModel>>(entities);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to load entities!", ex);
            }
        }

        public virtual async Task CreateAsync(TModel model)
        {
            try
            {
                var entity = Mapper.Map<TEntity>(model);
                await Repository.CreateAsync(entity);
                await UoW.SaveAsync();
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to create entity!", ex);
            }
        }

        public virtual async Task UpdateAsync(Guid id, TModel model)
        {
            try
            {
                var entity = await Repository.GetByIdAsync(id);
                if (entity == null)
                    throw new BusinessException("Entity not found!");

                Mapper.Map(model, entity);
                await UoW.SaveAsync();
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to update entity!", ex);
            }
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            try
            {
                var entity = await Repository.GetByIdAsync(id);
                if (entity == null)
                    throw new BusinessException("Entity not found!");

                await Repository.DeleteAsync(id);
                await UoW.SaveAsync();
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Failed to delete entity!", ex);
            }
        }
    }
}
