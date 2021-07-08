using BusinessLogic.Interfaces.Base;
using BusinessLogic.Interfaces.Services;

namespace BusinessLogic.Interfaces
{
    public interface IAppBll : IBaseBll
    {
        IDiscountService Discounts { get; }
        IImageService Images { get; }
        IOrderItemService OrderItems { get; }
        IOrderService Orders { get; }
        IProductService Products { get; }
    }
}