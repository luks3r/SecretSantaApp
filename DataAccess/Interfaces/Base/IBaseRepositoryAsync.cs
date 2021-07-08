using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace DataAccess.Interfaces.Base
{
    public interface IBaseRepositoryAsync<TEntity, in TKey> : IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IEntityId<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TEntity?> FirstOrDefaultAsync(TKey id, TKey? userId = default, bool noTracking = true);
        Task<IEnumerable<TEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true);
        Task<bool> ExistsAsync(TKey id, TKey? userId = default);
        Task<TEntity> RemoveAsync(TKey id, TKey? userId = default);
    }
}