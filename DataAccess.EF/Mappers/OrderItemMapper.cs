using AutoMapper;
using DataAccess.EF.Base;
using Domain.Entities;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.Mappers
{
    public class OrderItemMapper : BaseMapper<Dal.OrderItem, OrderItem>
    {
        public OrderItemMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}