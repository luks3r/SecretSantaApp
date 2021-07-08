using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces.Services;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Repositories;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Services
{
    public class DiscountService
        : BaseEntityService<IAppUnitOfWork, IDiscountRepository, Discount, Dal.Discount>, IDiscountService
    {
        public DiscountService(
            IAppUnitOfWork serviceUow,
            IDiscountRepository serviceRepository,
            IMapper mapper
        ) : base(serviceUow, serviceRepository, new Mappers.DiscountMapper(mapper))
        {
        }
    }
}