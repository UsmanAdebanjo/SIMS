using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class Grade
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength (150)]
        public string Description { get; set; }
    }
}
