using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using DataAccess.Extensions;
using DataAccess.Interfaces.Base;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.EF.Base
{
    public class BaseRepository<TDalEntity, TDomainEntity, TDbContext>
        : BaseRepository<TDalEntity, TDomainEntity, Guid, TDbContext>
        where TDalEntity : class, IEntityId<Guid>
        where TDomainEntity : class, IEntityId<Guid>
        where TDbContext : DbContext
    {
        public BaseRepository(TDbContext dbContext, IBaseMapper<TDalEntity, TDomainEntity> mapper)
            : base(dbContext, mapper)
        {
        }
    }

    public class BaseRepository<TDalEntity, TDomainEntity, TKey, TDbContext>
        : IBaseRepository<TDalEntity, TKey>
        where TDalEntity : class, IEntityId<TKey>
        where TDomainEntity : class, IEntityId<TKey>
        where TKey : IEquatable<TKey>
        where TDbContext : DbContext
    {
        protected readonly TDbContext RepoDbContext;
        protected readonly DbSet<TDomainEntity> RepoDbSet;
        protected readonly IBaseMapper<TDalEntity, TDomainEntity> Mapper;

        private readonly Dictionary<TDalEntity, TDomainEntity> _entityCache = new();

        public BaseRepository(TDbContext dbContext, IBaseMapper<TDalEntity, TDomainEntity> mapper)
        {
            RepoDbContext = dbContext;
            RepoDbSet = dbContext.Set<TDomainEntity>();
            Mapper = mapper;
        }

        private static bool UserIdNotNull(TKey? userId)
        {
            return userId != null && !userId.Equals(default);
        }

        private static bool UserIdIsValid(TKey? userId)
        {
            return UserIdNotNull(userId) && typeof(IEntityId<TKey>).IsAssignableFrom(typeof(TDomainEntity));
        }

        private TDalEntity MapWithCallback(
            TDalEntity entity,
            Func<TDomainEntity, EntityEntry<TDomainEntity>> callback
        ) =>
            Mapper.MapWithCallback<TDalEntity, TDomainEntity, TKey>(entity,
                domainEntity => callback(domainEntity).Entity);

        public virtual TDalEntity Add(TDalEntity entity)
        {
            return Mapper.MapWithCallback<TDalEntity, TDomainEntity, TKey>(entity, domainEntity =>
            {
                _entityCache.Add(entity, domainEntity);
                return RepoDbSet.Add(domainEntity).Entity;
            });
        }

        public virtual TDalEntity Update(TDalEntity entity)
        {
            return MapWithCallback(entity, RepoDbSet.Update);
        }

        public virtual TDalEntity Remove(TDalEntity entity, TKey? userId = default)
        {
            if (UserIdIsValid(userId) && !entity.IsOwnedBy(userId))
                throw new AuthenticationException(
                    $"Bad user id inside entity {typeof(TDalEntity).Name} to be deleted.");

            return MapWithCallback(entity, RepoDbSet.Remove);
        }

        public TDalEntity GetUpdatedEntityAfterSaveChanges(TDalEntity entity)
        {
            var updatedEntity = _entityCache[entity]!;
            return Mapper.Map(updatedEntity)!;
        }

        protected IQueryable<TDomainEntity> CreateQuery(TKey? userId = default, bool noTracking = true)
        {
            var query = RepoDbSet.AsQueryable();

            if (UserIdIsValid(userId))
                query = query.Where(e => e.IsOwnedBy(userId));

            return noTracking ? query.AsNoTracking() : query;
        }

        public virtual async Task<TDalEntity?> FirstOrDefaultAsync(TKey id, TKey? userId = default,
            bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            return Mapper.Map(await query.FirstOrDefaultAsync(e => e.Id.Equals(id)));
        }

        public virtual async Task<IEnumerable<TDalEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true)
        {
            var query = CreateQuery(userId, noTracking);
            var resQuery = query.Select(domainEntity => Mapper.Map(domainEntity));
            var res = await resQuery.ToListAsync();

            return res!;
        }

        public virtual async Task<bool> ExistsAsync(TKey id, TKey? userId = default)
        {
            if (!UserIdNotNull(userId))
                return await RepoDbSet.AnyAsync(e => e.Id.Equals(id));

            if (!typeof(IEntityId<TKey>).IsAssignableFrom(typeof(TDomainEntity)))
                throw new AuthenticationException(
                    $"Entity {typeof(TDomainEntity).Name} does not implement required interface: {typeof(IEntityId<TKey>).Name} for EntityUserId check");

            return await RepoDbSet.AnyAsync(e => e.Id.Equals(id) && e.IsOwnedBy(userId));
        }

        public virtual async Task<TDalEntity> RemoveAsync(TKey id, TKey? userId = default)
        {
            var entity = await FirstOrDefaultAsync(id, userId);
            if (entity == null)
                throw new NullReferenceException($"Entity {typeof(TDalEntity).Name} with id {id} not found.");
            return Remove(entity!, userId);
        }
    }
}