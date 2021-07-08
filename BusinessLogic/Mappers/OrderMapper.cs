using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Entities;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Mappers
{
    public class OrderMapper : BaseMapper<Order, Dal.Order>
    {
        public OrderMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}