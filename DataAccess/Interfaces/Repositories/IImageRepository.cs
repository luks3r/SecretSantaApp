using DataAccess.Interfaces.Base;
using DataAccess.Entities;

namespace DataAccess.Interfaces.Repositories
{
    public interface IImageRepository : IBaseRepository<Image>, IImageRepositoryCustom<Image>
    {
    }

    public interface IImageRepositoryCustom<TEntity>
    {
    }
}