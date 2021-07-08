using BusinessLogic.Entities;
using BusinessLogic.Interfaces.Base;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Interfaces.Services
{
    public interface IProductService : IBaseEntityService<Product, Dal.Product>
    {
    }
}