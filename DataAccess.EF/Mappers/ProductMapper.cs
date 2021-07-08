using AutoMapper;
using DataAccess.EF.Base;
using Domain.Entities;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.Mappers
{
    public class ProductMapper : BaseMapper<Dal.Product, Product>
    {
        public ProductMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}