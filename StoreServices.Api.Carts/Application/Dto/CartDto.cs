namespace StoreServices.Api.Carts.Application.Dto
{
    public class CartDto
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<CartItemsDto> ListaProdutos { get; set; }
    }
}
