using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [StringLength(20)]
        [Required]
        public string Class { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
