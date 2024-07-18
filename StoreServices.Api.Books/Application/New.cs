using FluentValidation;
using MediatR;
using StoreServices.Api.Books.Data;
using StoreServices.Api.Books.Model;

namespace StoreServices.Api.Books.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime PublishDate { get; set; }
            public Guid? AuthorId { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly ContextBook _context;

            public Handler(ContextBook context)
            {
                _context = context;
            }

            public async Task Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new Book
                {
                    Title = request.Title,
                    PublishDate = request.PublishDate,
                    AuthorId = request.AuthorId,
                };

                _context.Books.Add(book);
                var result = await _context.SaveChangesAsync();
                if (result < 1)
                    throw new Exception("Cannot insert book");
            }
        }

        public class ExecuteValidator : AbstractValidator<Execute>
        {
            public ExecuteValidator() 
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.AuthorId).NotEmpty();
                RuleFor(x => x.PublishDate).NotEmpty();
            }
        }
    }
}
