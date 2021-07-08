using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces.Services;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Repositories;
using Dal = DataAccess.Entities;

namespace BusinessLogic.Services
{
    public class ImageService
        : BaseEntityService<IAppUnitOfWork, IImageRepository, Image, Dal.Image>, IImageService
    {
        public ImageService(
            IAppUnitOfWork serviceUow,
            IImageRepository serviceRepository,
            IMapper mapper
        ) : base(serviceUow, serviceRepository, new Mappers.ImageMapper(mapper))
        {
        }
    }
}