using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Model;

namespace StoreServices.Api.Author.Data
{
    public class ContextAuthor : DbContext
    {
        public ContextAuthor(DbContextOptions<ContextAuthor> options):base(options) { }

        public DbSet<AuthorBook> Authors { get; set; }  
        public DbSet<AcademicDegree> AcademicDegree { get; set;}
    }
}
