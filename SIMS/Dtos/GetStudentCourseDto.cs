using SIMS.Models;

namespace SIMS.Dtos
{
    public class GetStudentCourseDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Guid GradeId { get; set; }

        public CourseDto Course { get; set; }
        public StudentDto Student { get; set; }
        public GradeDto Grade { get; set; }

    }
}
