using System;
using Domain.Interfaces;

namespace DataAccess.Interfaces.Base
{
    public interface IBaseRepositoryCommon<TEntity, in TKey>
        where TEntity : class, IEntityId<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity, TKey? userId = default);

        TEntity GetUpdatedEntityAfterSaveChanges(TEntity entity);
    }
}