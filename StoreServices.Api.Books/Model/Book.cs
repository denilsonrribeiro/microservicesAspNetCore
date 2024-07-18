﻿namespace StoreServices.Api.Books.Model
{
    public class Book
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid? AuthorId { get; set; }
    }
}
