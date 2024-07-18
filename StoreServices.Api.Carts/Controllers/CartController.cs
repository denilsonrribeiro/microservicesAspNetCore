using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreServices.Api.Carts.Application;
using StoreServices.Api.Carts.Application.Dto;

namespace StoreServices.Api.Carts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Create(New.AddBookCartCommand bookCart)
        {
            await _mediator.Send(bookCart);
        }

        [HttpGet("GetCartById")]
        public async Task<CartDto> GetCartById(int cartId)
        {
            return await _mediator.Send(new Query.GetCartByIdQuery { CartId = cartId });
        }
    }
}
