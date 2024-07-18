using StoreServices.Api.Author.Model;

namespace StoreServices.Api.Author.Application.Dto
{
    public class AuthorBookDto
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime? DateBirth { get; set; }
        public string AuthorGuid { get; set; }
    }
}
