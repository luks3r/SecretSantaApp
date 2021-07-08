using System;

namespace Domain.Interfaces
{
    public interface IEntity : IEntityId, IEntityMeta
    {
    }

    public interface IEntity<TKey> : IEntityId<TKey>, IEntityMeta
        where TKey : IEquatable<TKey>
    {
    }
}