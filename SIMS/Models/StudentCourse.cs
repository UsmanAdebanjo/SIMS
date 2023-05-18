namespace SIMS.Models
{
    public class StudentCourse
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Guid GradeId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
        public Grade Grade { get; set; }
    }
}
