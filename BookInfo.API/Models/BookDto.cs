using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BookInfo.API.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Section { get; set; } = string.Empty; // "string.Empty" initializes the property with an empty string by default
        public string? Description { get; set; }  // This property can be null

        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = // To extend BookDto class so it includes a collection ofpointofinterest
            new List<PointOfInterestDto>();
    }
}
