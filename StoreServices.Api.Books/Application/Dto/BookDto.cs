namespace StoreServices.Api.Books.Application.Dto
{
    public class BookDto
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid? AuthorId { get; set; }
    }
}
