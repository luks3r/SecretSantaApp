using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces.Services;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Repositories;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Services
{
    public class OrderItemService
        : BaseEntityService<IAppUnitOfWork, IOrderItemRepository, OrderItem, Dal.OrderItem>, IOrderItemService
    {
        public OrderItemService(
            IAppUnitOfWork serviceUow,
            IOrderItemRepository serviceRepository,
            IMapper mapper
        ) : base(serviceUow, serviceRepository, new Mappers.OrderItemMapper(mapper))
        {
        }
    }
}