using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Entities;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Mappers
{
    public class ProductMapper : BaseMapper<Product, Dal.Product>
    {
        public ProductMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}