using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Carts.Application.Dto;
using StoreServices.Api.Carts.Data;
using StoreServices.Api.Carts.Model;
using StoreServices.Api.Carts.RemoteInterface;
using System.Security.Cryptography.Xml;

namespace StoreServices.Api.Carts.Application
{
    public class Query
    {
        public class GetCartByIdQuery : IRequest<CartDto>
        {
            public int CartId { get; set; }
        }

        public class GetAllBooksQueryHandler : IRequestHandler<GetCartByIdQuery, CartDto>
        {
            private readonly ContextCart _contextCart;
            private readonly IBookService _bookService;

            public GetAllBooksQueryHandler(ContextCart contextCart, IBookService bookService)
            {
                _contextCart = contextCart;
                _bookService = bookService;
            }

            public async Task<CartDto> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
            {
                var cart = await _contextCart.Carts.FirstOrDefaultAsync(x => x.Id == request.CartId);
                var cartItems = await _contextCart.CartsItems.Where(x => x.CartId == request.CartId).ToListAsync();

                var listCartItemsDto = new List<CartItemsDto>();

                foreach (var item in cartItems)
                {
                    var response = await _bookService.GetBook(Guid.Parse(item.Product));
                    if (response.resultado)
                    {
                        var objBook = response.Item2;
                        var cartItem = new CartItemsDto
                        {
                            Title = objBook.Title,
                            PublishDate = objBook.PublishDate,
                            BookId = objBook.Id
                        };

                        listCartItemsDto.Add(cartItem);
                    }
                }

                var cartDto = new CartDto
                {
                    Id = cart.Id,
                    CreatedAt = cart.CreatedAt,
                    ListaProdutos = listCartItemsDto
                };

                return cartDto;
            }
        }
    }
}
