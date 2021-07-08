using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interfaces.Base;
using DataAccess.Extensions;
using dalBase = DataAccess.Interfaces.Base;
using Domain.Interfaces;

namespace BusinessLogic.Base
{
    public class BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalEntity>
        : BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalEntity, Guid>,
            IBaseEntityService<TBllEntity, TDalEntity>
        where TBllEntity : class, IEntityId<Guid>
        where TDalEntity : class, IEntityId<Guid>
        where TUnitOfWork : dalBase.IBaseUnitOfWork
        where TRepository : dalBase.IBaseRepository<TDalEntity, Guid>
    {
        public BaseEntityService(TUnitOfWork serviceUow, TRepository serviceRepository,
            IBaseMapper<TBllEntity, TDalEntity> mapper) : base(serviceUow, serviceRepository, mapper)
        {
        }
    }

    public class BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalEntity, TKey>
        : IBaseEntityService<TBllEntity, TDalEntity, TKey>
        where TKey : IEquatable<TKey>
        where TBllEntity : class, IEntityId<TKey>
        where TDalEntity : class, IEntityId<TKey>
        where TUnitOfWork : dalBase.IBaseUnitOfWork
        where TRepository : dalBase.IBaseRepository<TDalEntity, TKey>
    {
        protected readonly TUnitOfWork ServiceUow;
        protected readonly TRepository ServiceRepository;
        protected readonly IBaseMapper<TBllEntity, TDalEntity> Mapper;

        private readonly Dictionary<TBllEntity, TDalEntity> _entityCache = new();

        public BaseEntityService(TUnitOfWork serviceUow, TRepository serviceRepository,
            IBaseMapper<TBllEntity, TDalEntity> mapper)
        {
            ServiceUow = serviceUow;
            ServiceRepository = serviceRepository;
            Mapper = mapper;
        }

        private TBllEntity MapWithCallback(TBllEntity entity, Func<TDalEntity, TDalEntity> callback) =>
            Mapper.MapWithCallback<TBllEntity, TDalEntity, TKey>(entity, callback);

        public TBllEntity Add(TBllEntity entity)
        {
            return MapWithCallback(entity, dalEntity =>
            {
                _entityCache.Add(entity, dalEntity);
                return ServiceRepository.Add(dalEntity);
            });
        }

        public TBllEntity Update(TBllEntity entity)
        {
            return MapWithCallback(entity, ServiceRepository.Update);
        }

        public TBllEntity Remove(TBllEntity entity, TKey? userId = default)
        {
            return MapWithCallback(entity, dalEntity => ServiceRepository.Remove(dalEntity, userId));
        }

        public TBllEntity GetUpdatedEntityAfterSaveChanges(TBllEntity entity)
        {
            var dalEntity = _entityCache[entity]!;
            var updatedDalEntity = ServiceRepository.GetUpdatedEntityAfterSaveChanges(dalEntity);
            return Mapper.Map(updatedDalEntity)!;
        }

        public async Task<TBllEntity?> FirstOrDefaultAsync(TKey id, TKey? userId = default, bool noTracking = true)
        {
            return Mapper.Map(await ServiceRepository.FirstOrDefaultAsync(id, userId, noTracking));
        }

        public async Task<IEnumerable<TBllEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true)
        {
            var entities = await ServiceRepository.GetAllAsync(userId, noTracking);
            return entities.Select(entity => Mapper.Map(entity))!;
        }

        public async Task<bool> ExistsAsync(TKey id, TKey? userId = default)
        {
            return await ServiceRepository.ExistsAsync(id, userId);
        }

        public async Task<TBllEntity> RemoveAsync(TKey id, TKey? userId = default)
        {
            return Mapper.Map(await ServiceRepository.RemoveAsync(id, userId))!;
        }
    }
}