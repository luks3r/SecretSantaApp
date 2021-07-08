using AutoMapper;
using DataAccess.EF.Base;
using Domain.Entities;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.Mappers
{
    public class OrderMapper : BaseMapper<Dal.Order, Order>
    {
        public OrderMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}