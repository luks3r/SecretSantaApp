using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Entities;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Mappers
{
    public class DiscountMapper : BaseMapper<Discount, Dal.Discount>
    {
        public DiscountMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}