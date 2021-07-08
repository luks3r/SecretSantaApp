using DataAccess.Interfaces.Base;
using DataAccess.Interfaces.Repositories;

namespace DataAccess.Interfaces
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IDiscountRepository Discounts { get; }
        IImageRepository Images { get; }
        IOrderItemRepository OrderItems { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
    }
}