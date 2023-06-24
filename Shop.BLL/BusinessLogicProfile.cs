using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;

namespace Shop.BLL
{
    public class BusinessLogicProfile : Profile
    {
        public BusinessLogicProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Detail, DetailModel>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailModel>().ReverseMap();
            CreateMap<CartItem, CartItemModel>();
        }
    }
}
