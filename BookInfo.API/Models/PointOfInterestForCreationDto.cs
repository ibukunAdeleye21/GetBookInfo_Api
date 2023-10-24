using System.ComponentModel.DataAnnotations;

namespace BookInfo.API.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Author { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
