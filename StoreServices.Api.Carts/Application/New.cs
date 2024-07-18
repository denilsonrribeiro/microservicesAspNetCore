using FluentValidation;
using MediatR;
using StoreServices.Api.Carts.Data;
using StoreServices.Api.Carts.Model;

namespace StoreServices.Api.Carts.Application
{
    public class New
    {
        public class AddBookCartCommand : IRequest
        {
            public DateTime CreatedAt { get; set; }

            public List<string> Products { get; set; }
        }

        public class AddBookCartHandler : IRequestHandler<AddBookCartCommand>
        {
            private readonly ContextCart _contextCart;

            public AddBookCartHandler(ContextCart contextCart)
            {
                _contextCart = contextCart;
            }

            public async Task Handle(AddBookCartCommand request, CancellationToken cancellationToken)
            {
                var cart = new Cart
                {
                    CreatedAt = request.CreatedAt
                };

                _contextCart.Carts.Add(cart);
                var result = await _contextCart.SaveChangesAsync();
                if (result == 0)
                    throw new Exception("Cannot enable create cart");

                var id = cart.Id;

                foreach (var item in request.Products)
                {
                    var cartItem = new CartItems
                    {
                        CreatedAt = DateTime.Now,
                        CartId = id,
                        Product = item
                    };

                    _contextCart.CartsItems.Add(cartItem);
                }
                
                result = await _contextCart.SaveChangesAsync();
                if (result == 0)
                    throw new Exception("Cannot enable insert cart itens");
            }
        }

        public class AddBookCartValidator : AbstractValidator<AddBookCartCommand>
        {
            public AddBookCartValidator()
            {
                RuleFor(x => x.CreatedAt).NotEmpty();
                RuleFor(x => x.Products).NotEmpty();
            }
        }
    }
}
