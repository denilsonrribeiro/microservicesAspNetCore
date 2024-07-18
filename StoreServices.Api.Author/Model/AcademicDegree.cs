using FluentValidation;

namespace StoreServices.Api.Author.Model
{
    public class AcademicDegree : Base
    {
        public int Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime? GraduationDate { get; set; }
        public int AuthorId { get; set; }
        public AuthorBook Author { get; set; }
        public string AcademicDegreeGuid { get; set; }
    }

    public class AcademicDegreeValidator : AbstractValidator<AcademicDegree>
    {
        public AcademicDegreeValidator() 
        {
            
        }
    }

}
