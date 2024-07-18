namespace StoreServices.Api.Carts.Application.Dto
{
    public class CartItemsDto
    {
        public Guid? BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
