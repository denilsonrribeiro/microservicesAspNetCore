using AutoMapper;
using StoreServices.Api.Author.Application.Dto;
using StoreServices.Api.Author.Model;

namespace StoreServices.Api.Author.Application.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<AuthorBook, AuthorBookDto>().ReverseMap();
        }
    }
}
