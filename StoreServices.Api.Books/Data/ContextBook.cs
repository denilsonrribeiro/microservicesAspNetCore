using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Books.Model;

namespace StoreServices.Api.Books.Data
{
    public class ContextBook : DbContext
    {
        public ContextBook() { }
        public ContextBook(DbContextOptions<ContextBook> options): base(options){ }

        public virtual DbSet<Book> Books { get; set; }
    }
}
