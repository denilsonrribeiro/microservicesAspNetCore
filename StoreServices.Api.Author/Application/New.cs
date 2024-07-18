using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Author.Data;
using StoreServices.Api.Author.Model;

namespace StoreServices.Api.Author.Application
{
    public class New
    {
        public class Execute: IRequest
        {
            public string Name { get; set; }
            public string Alias { get; set; }
            public DateTime? DateBirth { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            public readonly ContextAuthor _context;

            public Handler(ContextAuthor context)
            {
                _context = context;
            }

            public async Task Handle(Execute request, CancellationToken cancellationToken)
            {
                var author = new AuthorBook
                {
                    Name = request.Name,
                    Alias = request.Alias,
                    DateBirth = request.DateBirth,
                    AuthorGuid = Guid.NewGuid().ToString()
                };

                _context.Authors.Add(author);
                var result = await _context.SaveChangesAsync();
                if (result < 1)
                {
                    throw new Exception("Cannot insert author");
                }
            }
        }

        public class ExecuteValidador : AbstractValidator<Execute>
        {
            public ExecuteValidador()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Alias).NotEmpty();
            }
        }
    }
}
