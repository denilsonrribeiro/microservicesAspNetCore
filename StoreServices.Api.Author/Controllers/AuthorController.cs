using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Author.Application;
using StoreServices.Api.Author.Application.Dto;
using StoreServices.Api.Author.Model;

namespace StoreServices.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Create(New.Execute data)
        {
            await _mediator.Send(data);
        }

        [HttpGet("GetAuthors")]
        public async Task<ActionResult<List<AuthorBookDto>>> GetAuthors()
        {
            return await _mediator.Send(new Query.ListAuthor());
        }

        [HttpGet("GetAuthor")]
        public async Task<ActionResult<AuthorBookDto>> GetAuthor(string id)
        {
            return await _mediator.Send(new QueryFilter.UniqueAuthor{ AuthorGuid = id});
        }
    }
}
