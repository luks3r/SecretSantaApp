using System;
using DataAccess.Interfaces.Base;
using Domain.Interfaces;

namespace BusinessLogic.Interfaces.Base
{
    public interface IBaseEntityService<TBllEntity, TDalEntity> : IBaseEntityService<TBllEntity, TDalEntity, Guid>
        where TBllEntity : class, IEntityId<Guid>
        where TDalEntity : class, IEntityId<Guid>
    {
    }

    public interface IBaseEntityService<TBllEntity, TDalEntity, in TKey> : IBaseService,
        IBaseRepository<TBllEntity, TKey>
        where TBllEntity : class, IEntityId<TKey>
        where TDalEntity : class, IEntityId<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}