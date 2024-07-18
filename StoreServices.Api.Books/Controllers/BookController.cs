using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Books.Application;
using StoreServices.Api.Books.Application.Dto;

namespace StoreServices.Api.Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Create(New.Execute book)
        {
            await _mediator.Send(book);
        }

        [HttpGet("GetAll")]
        public async Task<List<BookDto>> GetAll()
        {
            return await _mediator.Send(new Query.Execute());
        }

        [HttpGet("GetById/{id}")]
        public async Task<BookDto> GetById(Guid id)
        {
            return await _mediator.Send(new QueryFilter.Execute { BookId = id});
        }
    }
}
