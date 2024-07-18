namespace StoreServices.Api.Carts.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
    }
}
