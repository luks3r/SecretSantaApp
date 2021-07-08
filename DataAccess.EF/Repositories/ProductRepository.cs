using AutoMapper;
using DataAccess.EF.Base;
using DataAccess.EF.Mappers;
using DataAccess.Interfaces.Repositories;
using Domain.Entities;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.Repositories
{
    public class ProductRepository : BaseRepository<Dal.Product, Product, AppDbContext>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext, IMapper mapper) :
            base(dbContext, new ProductMapper(mapper))
        {
        }
    }
}