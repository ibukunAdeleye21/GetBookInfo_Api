namespace BookInfo.API.Models
{
    public class PointOfInterestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Author { get; set; } 
        public string? Description { get; set; }
    }
}
