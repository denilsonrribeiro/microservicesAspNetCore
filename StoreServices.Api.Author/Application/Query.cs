using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Application.Dto;
using StoreServices.Api.Author.Data;
using StoreServices.Api.Author.Model;

namespace StoreServices.Api.Author.Application
{
    public class Query
    {
        public class ListAuthor : IRequest<List<AuthorBookDto>>{ }

        public class Handler : IRequestHandler<ListAuthor, List<AuthorBookDto>>
        {
            private readonly ContextAuthor _context;
            private readonly IMapper _mapper;

            public Handler(ContextAuthor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AuthorBookDto>> Handle(ListAuthor request, CancellationToken cancellationToken)
            {
                var authors = await _context.Authors.ToListAsync();
                var authorDto = _mapper.Map<List<AuthorBookDto>>(authors);
                return authorDto;
            }
        }
    }
}
