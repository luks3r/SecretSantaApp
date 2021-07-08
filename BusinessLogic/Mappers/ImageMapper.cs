using AutoMapper;
using BusinessLogic.Base;
using BusinessLogic.Entities;
using Dal = DataAccess.Entities;
namespace BusinessLogic.Mappers
{
    public class ImageMapper : BaseMapper<Image, Dal.Image>
    {
        public ImageMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}