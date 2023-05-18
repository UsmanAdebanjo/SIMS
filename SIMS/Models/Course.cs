using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class Course
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        [Required]
        public string CourseName { get; set; }
        [StringLength(10)]
        [Required]
        public string CourseCode { get; set; }
        [StringLength(150)]
        [Required]
        public string CourseTitle { get; set; }
    }
}
//restcountries.com