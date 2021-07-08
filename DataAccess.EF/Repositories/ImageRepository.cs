using AutoMapper;
using DataAccess.EF.Base;
using DataAccess.EF.Mappers;
using DataAccess.Interfaces.Repositories;
using Domain.Entities;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.Repositories
{
    public class ImageRepository : BaseRepository<Dal.Image, Image, AppDbContext>, IImageRepository
    {
        public ImageRepository(AppDbContext dbContext, IMapper mapper) :
            base(dbContext, new ImageMapper(mapper))
        {
        }
    }
}