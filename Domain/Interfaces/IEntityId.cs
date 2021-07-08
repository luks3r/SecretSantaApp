using System;

namespace Domain.Interfaces
{
    public interface IEntityId : IEntityId<Guid>
    {
    }

    public interface IEntityId<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}