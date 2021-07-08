using BusinessLogic.Entities;
using BusinessLogic.Interfaces.Base;
using DataAccess.Interfaces.Repositories;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Interfaces.Services
{
    public interface IDiscountService : IBaseEntityService<Discount, Dal.Discount>, IDiscountRepositoryCustom<Discount>
    {
    }
}