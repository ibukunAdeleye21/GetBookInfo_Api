using BookInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
namespace BookInfo.API.DbContext
{
    public class BookContextInfo : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;
        public DbSet<User> Users { get; set;} = null!;

        public BookContextInfo(DbContextOptions<BookContextInfo> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PointOfInterest>()
                    .HasOne(p => p.Book)
                    .WithMany(b => b.PointsOfInterest)
                    .HasForeignKey(p => p.BookId);

            modelBuilder.Entity<Book>()
                .HasData(
                new Book("Relationship Books")
                {
                    Id = 3,
                    Description = "Journey to Heartfelt Connections and Love."
                },
                new Book("Personal Growth Books")
                {
                    Id = 4,
                    Description = "Unleashing Potential: Your Journey to Self-Discovery."
                },
                new Book("Spiritual Books")
                {
                    Id = 5,
                    Description = "Unfolding the Mystical Pathway to Spiritual Transformation."
                });

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                new PointOfInterest("Men are from Mars, women are from Venus")
                {
                    Id = 5,
                    Author = "John Gray",
                    BookId = 3,
                    Description = "Nice Book."
                },
                new PointOfInterest("Waiting and Dating")
                {
                    Id = 6,
                    Author = "Myles Munroe",
                    BookId = 3,
                    Description = "Lovel Book"
                },
                new PointOfInterest("Atomic Habits")
                {
                    Id = 7,
                    Author = "James Clear",
                    BookId = 4,
                    Description = "Awesome Book."
                },
                new PointOfInterest("Awaken the Giant Within")
                {
                    Id = 8,
                    Author  = "Tony Robbins",
                    BookId = 4,
                    Description = "Great Book."
                },
                new PointOfInterest("God's General")
                {
                    Id = 9,
                    Author = "Robert Liadon",
                    BookId = 5,
                    Description = "Excellent Book."
                },
                new PointOfInterest("He leads me")
                {
                    Id = 10,
                    Author = "Gbile Akanni",
                    BookId = 5,
                    Description = "Good Book"
                });
               
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
