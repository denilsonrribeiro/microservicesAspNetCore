using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Carts.Model;

namespace StoreServices.Api.Carts.Data
{
    public class ContextCart : DbContext
    {
        public ContextCart(DbContextOptions<ContextCart> options): base(options) { }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItems> CartsItems { get; set; }
    }
}
