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
            CreateMap<DetailModel, DetailDto>()
                .ForMember(
                    dest => dest.Value,
                    opt => opt.MapFrom(src => src.ProductDetails.Single().Value));
            CreateMap<CartItemModel, CartItemDto>();
            CreateMap<PaginatedListModel<ProductModel>, ProductResultDto>()
                .ForMember(
                    dest => dest.CurrentPage,
                    opt => opt.MapFrom(src => src.PageIndex))
                .ForMember(
                    dest => dest.Products,
                    opt => opt.MapFrom(src => src.Items));
        }
    }
}
