using AutoMapper;
using Domain.Entities;
using Domain.Entities.Identity;
using Dal = DataAccess.Entities;

namespace DataAccess.EF.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Dal.Discount, Discount>().ReverseMap();
            CreateMap<Dal.Image, Image>().ReverseMap();
            CreateMap<Dal.Order, Order>().ReverseMap();
            CreateMap<Dal.OrderItem, OrderItem>().ReverseMap();
            CreateMap<Dal.Product, Product>().ReverseMap();

            CreateMap<Dal.Identity.User, User>().ReverseMap();
            CreateMap<Dal.Identity.Role, Role>().ReverseMap();
        }
    }
}