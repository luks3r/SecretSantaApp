using System;
using DataAccess.Interfaces.Base;
using Domain.Interfaces;

namespace DataAccess.Extensions
{
    public static class DomainExtensions
    {
        public static bool IsOwnedBy<TKey, TEntity>(this TEntity entity, TKey? userId)
            where TKey : IEquatable<TKey>
            where TEntity : class, IEntityId<TKey>
        {
            if (userId == null || userId.Equals(default)) return true;
            return ((IEntityUserId<TKey>) entity).AuthorId.Equals(userId);
        }

        public static TEntity MapWithCallback<TEntity, TMappedEntity, TKey>(
            this IBaseMapper<TEntity, TMappedEntity> mapper,
            TEntity entity,
            Func<TMappedEntity, TMappedEntity> callback
        )
            where TKey : IEquatable<TKey>
            where TEntity : class, IEntityId<TKey>
            where TMappedEntity : class, IEntityId<TKey>
        {
            var mappedEntity = mapper.Map(entity)!;
            var updatedEntity = callback(mappedEntity);
            return mapper.Map(updatedEntity)!;
        }
    }
}