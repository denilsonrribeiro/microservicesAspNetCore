using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Application.Dto;
using StoreServices.Api.Author.Data;
using StoreServices.Api.Author.Model;

namespace StoreServices.Api.Author.Application
{
    public class QueryFilter
    {
        public class UniqueAuthor : IRequest<AuthorBookDto>
        {
            public string AuthorGuid { get; set; }
        }

        public class Handler : IRequestHandler<UniqueAuthor, AuthorBookDto>
        {
            private readonly ContextAuthor _context;
            private readonly IMapper _mapper;

            public Handler(ContextAuthor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorBookDto> Handle(UniqueAuthor request, CancellationToken cancellationToken)
            {
                var author = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorGuid == request.AuthorGuid);
                var authorDto = _mapper.Map<AuthorBookDto>(author);
                if (author == null) 
                    throw new Exception("Author not found.");
                
                return authorDto;
            }
        }
    }
}
