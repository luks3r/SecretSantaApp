using System;
using Domain.Interfaces;

namespace DataAccess.Interfaces.Base
{
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity : class, IEntityId<Guid>
    {
    }

    public interface IBaseRepository<TEntity, in TKey> : IBaseRepositoryAsync<TEntity, TKey>
        where TEntity : class, IEntityId<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}