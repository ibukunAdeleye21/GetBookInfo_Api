using BookInfo.API.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BookInfo.API
{
    public class BooksDataStore
    {
        public List<BookDto> Books { get; set; } // a list of BookDto

        public static BooksDataStore Current { get; } = new BooksDataStore();
        public BooksDataStore()
        {
            // code to initialize the dummy data
            Books = new List<BookDto>()
            {
                new BookDto()
                {
                    Id = 1,
                    Section = "LeaderShip Books",
                    Description = "Empowering Visions for Aspiring Trailblazers.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Leadership 101: What every leader needs to know",
                            Author = "John C. Maxwell",
                            Description = "Top notch piece."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Dare to lead",
                            Author = "Andrew Roberts",
                            Description = "Lovely book."
                        }
                    }
                },
                new BookDto()
                {
                    Id = 2,
                    Section = "Finance Books",
                    Description = "Unlocking Wealth Secrets for Financial Freedom.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Rich Dad Poor Dad",
                            Author = "Robert Kiyosaki",
                            Description = "Fantastic book."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Parable of Dollars",
                            Author = "Sam Adeyemi",
                            Description = "Superb book."
                        }
                    }
                },
                new BookDto()
                {
                    Id = 3,
                    Section = "Relationship Books",
                    Description = "Journey to Heartfelt Connections and Love.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Men are from Mars, women are from Venus",
                            Author = "John Gray",
                            Description = "Nice book."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Boundaries in Dating",
                            Author = "Henry Cloud",
                            Description = "Interesting Book."
                        }
                    }
                },
                new BookDto()
                {
                    Id = 4,
                    Section = "Personal Growth Books",
                    Description = "Unleashing Potential: Your Journey to Self-Discovery.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 7,
                            Name = "Atomic Habits",
                            Author = "James Clear",
                            Description = "Awesome book."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 8,
                            Name = "Awaken the Giant within",
                            Author = "Tony Robbins",
                            Description = "Great Book."
                        }
                    }
                },
                new BookDto()
                {
                    Id = 5,
                    Section = "Spiritual Growth Books",
                    Description = "Unfolding the Mystical Pathway to Spiritual Transformation.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 9,
                            Name = "God's General",
                            Author = "Robert Liadon",
                            Description = "Excellent Book."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 10,
                            Name = "He leads me",
                            Author = "Gbile Akanni",
                            Description = "Good Book."
                        }
                    }
                }
            };
        }
    }
}
