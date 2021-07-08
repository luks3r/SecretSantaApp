using DataAccess.Interfaces.Base;
using DataAccess.Entities;

namespace DataAccess.Interfaces.Repositories
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>, IOrderItemRepositoryCustom<OrderItem>
    {
    }

    public interface IOrderItemRepositoryCustom<TEntity>
    {
    }
}