using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces.Services;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Repositories;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Services
{
    public class OrderService
        : BaseEntityService<IAppUnitOfWork, IOrderRepository, Order, Dal.Order>, IOrderService
    {
        public OrderService(
            IAppUnitOfWork serviceUow,
            IOrderRepository serviceRepository,
            IMapper mapper
        ) : base(serviceUow, serviceRepository, new Mappers.OrderMapper(mapper))
        {
        }
    }
}