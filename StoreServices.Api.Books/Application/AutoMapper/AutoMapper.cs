using AutoMapper;
using StoreServices.Api.Books.Application.Dto;
using StoreServices.Api.Books.Model;

namespace StoreServices.Api.Books.Application.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
