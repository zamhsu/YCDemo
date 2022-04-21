using AutoMapper;
using WebApi.Models.Db;
using WebApi.Models.Dtos;

namespace WebApi.Mappings
{
    public class ControllersProfile : Profile
    {
        public ControllersProfile()
        {
            CreateMap<Product, ProductDisplayDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductEditDto, Product>();
        }
    }
}
