using AutoMapper;
using StoreServices.Api.Carts.Application.Dto;
using StoreServices.Api.Carts.Model;

namespace StoreServices.Api.Carts.Application.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartItems, CartItemsDto>().ReverseMap();
        }
    }
}
