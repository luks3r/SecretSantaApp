using AutoMapper;
using DataAccess.EF.Base;
using DataAccess.EF.Mappers;
using DataAccess.Interfaces.Repositories;
using Domain.Entities;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.Repositories
{
    public class OrderItemRepository : BaseRepository<Dal.OrderItem, OrderItem, AppDbContext>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext dbContext, IMapper mapper) :
            base(dbContext, new OrderItemMapper(mapper))
        {
        }
    }
}