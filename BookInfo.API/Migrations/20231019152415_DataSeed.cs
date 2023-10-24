using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
