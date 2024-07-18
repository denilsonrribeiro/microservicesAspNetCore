namespace StoreServices.Api.Carts.RemoteModel
{
    public class BookRemote
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid? AuthorId { get; set; }
    }
}
