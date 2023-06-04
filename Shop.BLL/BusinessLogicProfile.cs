using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;
using Shop.IdentityApi.Models;

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
            CreateMap<Detail, DetailModel>();
            CreateMap<ProductDetail, ProductDetailModel>();
            CreateMap<CartItem, CartItemModel>();

            CreateMap<UserDataModel, UserModel>();
        }
    }
}
