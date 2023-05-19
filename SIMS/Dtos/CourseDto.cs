using System.ComponentModel.DataAnnotations;

namespace SIMS.Dtos
{
    public class CourseDto
    {

        [StringLength(50)]
        public string CourseName { get; set; }
        [StringLength(10)]
        public string CourseCode { get; set; }
        [StringLength(150)]
        public string CourseTitle { get; set; }
    }
}
