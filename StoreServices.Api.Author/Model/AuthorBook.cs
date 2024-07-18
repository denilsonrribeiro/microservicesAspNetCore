using FluentValidation;

namespace StoreServices.Api.Author.Model
{
    public class AuthorBook : Base
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime? DateBirth { get; set; }
        public ICollection<AcademicDegree> ListAcademicDegree { get; set; }
        public string AuthorGuid { get; set; }
    }
}
