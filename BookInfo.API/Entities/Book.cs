using BookInfo.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookInfo.API.Entities
{
    public class Book
    {
        [Key] // Primary Key
        // A new key will be generated as a city is added i.e. automatic generation of Id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // To make the Id an identity column
        public int Id { get; set; }

        [Required] 
        [MaxLength(100)]
        public string Section { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        public ICollection<PointOfInterest> PointsOfInterest { get; set; }  // To extend BookDto class so it includes a collection ofpointofinterest
            = new List<PointOfInterest>();

        public Book(string section)
        {
            Section = section;
        }
    }
}
