using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace DataAccess.Interfaces.Base
{
    public interface IBaseRepositorySync<TEntity, in TKey> : IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IEntityId<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntity FirstOrDefault(TKey id, TKey? userId = default, bool noTracking = true);
        IEnumerable<TEntity> GetAll(TKey? userId = default, bool noTracking = true);
        bool Exists(TKey id, TKey? userId = default);
        TEntity Remove(TKey id, TKey? userId = default);
    }
}