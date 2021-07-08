using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Entities;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Mappers
{
    public class OrderItemMapper : BaseMapper<OrderItem, Dal.OrderItem>
    {
        public OrderItemMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}