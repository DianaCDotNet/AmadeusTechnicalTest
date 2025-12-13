using System.ComponentModel.DataAnnotations;

namespace AmadeusWebAPI.Entities
{
    public class Airline
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The {0} field must have {1} characters or less")]
        public required string Name{ get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int NuberFlightsPerDay { get; set; }

        [StringLength(50, ErrorMessage = "The {0} field must have {1} characters or less")]
        public string? OriginCountry { get; set; }

        [StringLength(20, ErrorMessage = "The {0} field must have {1} characters or less")]
        public string? ExternalIdentification { get; set; }

        [StringLength(150, ErrorMessage = "The {0} field must have {1} characters or less")]
        public string? AditionalInformation { get; set; }
    }
}
