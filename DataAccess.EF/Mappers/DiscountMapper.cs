using AutoMapper;
using DataAccess.EF.Base;
using Domain.Entities;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.Mappers
{
    public class DiscountMapper : BaseMapper<Dal.Discount, Discount>
    {
        public DiscountMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}