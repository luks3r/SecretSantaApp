using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces.Services;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Repositories;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Services
{
    public class ProductService
        : BaseEntityService<IAppUnitOfWork, IProductRepository, Product, Dal.Product>, IProductService
    {
        public ProductService(
            IAppUnitOfWork serviceUow,
            IProductRepository serviceRepository,
            IMapper mapper
        ) : base(serviceUow, serviceRepository, new Mappers.ProductMapper(mapper))
        {
        }
    }
}