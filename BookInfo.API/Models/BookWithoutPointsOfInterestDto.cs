namespace BookInfo.API.Models
{
    public class BookWithoutPointsOfInterestDto
    {
        public int Id { get; set; }
        public string Section { get; set; } = string.Empty;
        public string? Description { get; set; }

    }
}
