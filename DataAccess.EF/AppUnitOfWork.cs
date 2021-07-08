using AutoMapper;
using DataAccess.EF.Base;
using DataAccess.EF.Repositories;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Repositories;

namespace DataAccess.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        protected IMapper Mapper;

        public AppUnitOfWork(AppDbContext uowDbContext, IMapper mapper) : base(uowDbContext)
        {
            Mapper = mapper;
        }

        public IDiscountRepository Discounts =>
            GetRepository<IDiscountRepository>(() => new DiscountRepository(UowDbContext, Mapper));

        public IImageRepository Images =>
            GetRepository<IImageRepository>(() => new ImageRepository(UowDbContext, Mapper));

        public IOrderItemRepository OrderItems =>
            GetRepository<IOrderItemRepository>(() => new OrderItemRepository(UowDbContext, Mapper));

        public IOrderRepository Orders =>
            GetRepository<IOrderRepository>(() => new OrderRepository(UowDbContext, Mapper));

        public IProductRepository Products =>
            GetRepository<IProductRepository>(() => new ProductRepository(UowDbContext, Mapper));
    }
}