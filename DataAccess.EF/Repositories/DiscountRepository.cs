using AutoMapper;
using DataAccess.EF.Base;
using DataAccess.EF.Mappers;
using DataAccess.Interfaces.Repositories;
using Domain.Entities;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.Repositories
{
    public class DiscountRepository : BaseRepository<Dal.Discount, Discount, AppDbContext>, IDiscountRepository
    {
        public DiscountRepository(AppDbContext dbContext, IMapper mapper) :
            base(dbContext, new DiscountMapper(mapper))
        {
        }
    }
}