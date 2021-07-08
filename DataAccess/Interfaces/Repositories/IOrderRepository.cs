using DataAccess.Interfaces.Base;
using DataAccess.Entities;

namespace DataAccess.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>, IOrderRepositoryCustom<Order>
    {
    }

    public interface IOrderRepositoryCustom<TEntity>
    {
    }
}