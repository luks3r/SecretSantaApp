using DataAccess.Interfaces.Base;
using DataAccess.Entities;

namespace DataAccess.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>, IProductRepositoryCustom<Product>
    {
    }

    public interface IProductRepositoryCustom<TEntity>
    {
    }
}