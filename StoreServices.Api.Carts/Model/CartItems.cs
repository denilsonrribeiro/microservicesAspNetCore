namespace StoreServices.Api.Carts.Model
{
    public class CartItems
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Product { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
