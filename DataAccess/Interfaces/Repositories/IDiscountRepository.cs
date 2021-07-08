using DataAccess.Interfaces.Base;
using DataAccess.Entities;

namespace DataAccess.Interfaces.Repositories
{
    public interface IDiscountRepository : IBaseRepository<Discount>, IDiscountRepositoryCustom<Discount>
    {
    }

    public interface IDiscountRepositoryCustom<TEntity>
    {
    }
}