using AutoMapper;
using StoreServices.Api.Books.Application.Dto;
using StoreServices.Api.Books.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServices.Api.Books.Test
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
