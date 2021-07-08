using AutoMapper;
using DataAccess.EF.Base;
using Domain.Entities;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.Mappers
{
    public class ImageMapper : BaseMapper<Dal.Image, Image>
    {
        public ImageMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}