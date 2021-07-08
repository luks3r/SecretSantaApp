using System;

namespace Domain.Interfaces
{
    public interface IEntityUserId : IEntityUserId<Guid>
    {
    }

    public interface IEntityUserId<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey AuthorId { get; set; }
    }
}