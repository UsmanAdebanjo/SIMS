using System.ComponentModel.DataAnnotations;

namespace SIMS.Dtos
{
    public class GradeDto
    {
            
            [StringLength(50)]
            public string Title { get; set; }
            [Required]
            [StringLength(150)]
            public string Description { get; set; }
    }

}

