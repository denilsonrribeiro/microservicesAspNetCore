using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Books.Application.Dto;
using StoreServices.Api.Books.Data;

namespace StoreServices.Api.Books.Application
{
    public class Query
    {
        public class Execute : IRequest<List<BookDto>>{ }

        public class Handler : IRequestHandler<Execute, List<BookDto>>
        {
            private readonly ContextBook _context;
            private readonly IMapper _mapper;

            public Handler(ContextBook context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BookDto>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var books = await _context.Books.ToListAsync();
                var booksDto = _mapper.Map<List<BookDto>>(books);
                return booksDto;
            }
        }
    }
}
