using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Services;
using DataAccess.Interfaces;

namespace BusinessLogic
{
    public class AppBll : BaseBll<IAppUnitOfWork>, IAppBll
    {
        protected readonly IMapper Mapper;

        public AppBll(IAppUnitOfWork uow, IMapper mapper)
            : base(uow)
        {
            Mapper = mapper;
        }

        public IDiscountService Discounts =>
            GetService<IDiscountService>(() => new DiscountService(Uow, Uow.Discounts, Mapper));

        public IImageService Images =>
            GetService<IImageService>(() => new ImageService(Uow, Uow.Images, Mapper));

        public IOrderItemService OrderItems =>
            GetService<IOrderItemService>(() => new OrderItemService(Uow, Uow.OrderItems, Mapper));

        public IOrderService Orders =>
            GetService<IOrderService>(() => new OrderService(Uow, Uow.Orders, Mapper));

        public IProductService Products =>
            GetService<IProductService>(() => new ProductService(Uow, Uow.Products, Mapper));
    }
}