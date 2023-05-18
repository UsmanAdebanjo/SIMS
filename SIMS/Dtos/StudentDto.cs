using System.ComponentModel.DataAnnotations;

namespace SIMS.Dtos
{
    public class StudentDto
    {
        //public Guid Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string Class { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
