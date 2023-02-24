using System.ComponentModel.DataAnnotations;

namespace ApiWEb.Models.DataModels
{
    public class Student: BaseEntity
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }= string.Empty;
        [Required, StringLength(100)]
        public string LastName { get; set; }= string.Empty;
        [Required]
        public DateTime Dob { get; set; }

        public ICollection<Course> Courses { get; set; }= new List<Course>();
    }
}
