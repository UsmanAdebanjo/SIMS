using System.ComponentModel.DataAnnotations;

namespace SIMS.Dtos
{
    public class Holiday
    {
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]

        public DateTime? Date { get; set; }
        public string? LocalName { get; set; }
        public string? Name { get; set; }
        public bool Fixed { get; set; }
        public bool Global { get; set; }
        public string? CountryCode { get; set; }
        public string? Counties { get; set; }

        public int? LaunchYear { get; set; }
        public string[] Types { get; set; }
    }
}
