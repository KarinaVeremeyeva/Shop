using AutoMapper;
using Shop.Api.DTOs;
using Shop.BLL.Models;

namespace Shop.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryModel, CategoryDto>();
            CreateMap<ProductModel, ProductDto>()
                .ForMember(
                dest => dest.Details,
                opt => opt.MapFrom(src => src.Details));
            CreateMap<DetailModel, DetailsDto>();
        }
    }
}
