using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Section" },
                values: new object[,]
                {
                    { 3, "Journey to Heartfelt Connections and Love.", "Relationship Books" },
                    { 4, "Unleashing Potential: Your Journey to Self-Discovery.", "Personal Growth Books" },
                    { 5, "Unfolding the Mystical Pathway to Spiritual Transformation.", "Spiritual Books" }
                });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "Author", "BookId", "Description", "Name" },
                values: new object[,]
                {
                    { 5, "John Gray", 3, "Nice Book.", "Men are from Mars, women are from Venus" },
                    { 6, "Myles Munroe", 3, "Lovel Book", "Waiting and Dating" },
                    { 7, "James Clear", 4, "Awesome Book.", "Atomic Habits" },
                    { 8, "Tony Robbins", 4, "Great Book.", "Awaken the Giant Within" },
                    { 9, "Robert Liadon", 5, "Excellent Book.", "God's General" },
                    { 10, "Gbile Akanni", 5, "Good Book", "He leads me" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Section" },
                values: new object[,]
                {
                    { 1, "Empowering Visions for Aspiring Trailblazers.", "Leadership Book" },
                    { 2, "Unlocking Wealth Secrets for Financial Freedom", "Finance Books" }
                });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "Author", "BookId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "John C. Maxwell", 1, "Top notch piece.", "Leadership 101: What every leader needs to know." },
                    { 2, "Andrew Roberts", 1, "Lovely Book.", "Dare to Lead" },
                    { 3, "Robert Kiyosaki", 2, "Fantastic Book.", "Rich Dad Poor Dad" },
                    { 4, "Sam Adeyemi", 2, "Superb Book.", "Parable of Dollars" }
                });
        }
    }
}
