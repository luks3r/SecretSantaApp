using AutoMapper;
using DataAccess.EF.Base;
using DataAccess.EF.Mappers;
using DataAccess.Interfaces.Repositories;
using Domain.Entities;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.Repositories
{
    public class OrderRepository : BaseRepository<Dal.Order, Order, AppDbContext>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext, IMapper mapper) :
            base(dbContext, new OrderMapper(mapper))
        {
        }
    }
}