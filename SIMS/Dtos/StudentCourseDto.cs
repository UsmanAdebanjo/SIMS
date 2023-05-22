using SIMS.Models;

namespace SIMS.Dtos
{
    public class StudentCourseDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Guid GradeId { get; set; }
    }
}
