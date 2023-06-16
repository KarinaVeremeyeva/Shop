using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;

namespace Shop.BLL
{
    public class BusinessLogicProfile : Profile
    {
        public BusinessLogicProfile()
        {
            CreateMap<Category, CategoryModel>();
            CreateMap<Product, ProductModel>()
                .ForMember(
                    dest => dest.Details,
                    opt => opt.MapFrom(src => src.Details));
            CreateMap<Detail, DetailModel>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailModel>();
            CreateMap<CartItem, CartItemModel>();
        }
    }
}
