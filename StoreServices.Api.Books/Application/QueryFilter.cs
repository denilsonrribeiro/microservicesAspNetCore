using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Books.Application.Dto;
using StoreServices.Api.Books.Data;

namespace StoreServices.Api.Books.Application
{
    public class QueryFilter
    {
        public class Execute : IRequest<BookDto>
        {
            public Guid BookId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, BookDto>
        {
            private readonly ContextBook _context;
            private readonly IMapper _mapper;

            public Handler(ContextBook context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId);
                var bookDto = _mapper.Map<BookDto>(book);
                return bookDto;
            }
        }
    }
}
