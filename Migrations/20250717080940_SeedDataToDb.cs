using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Industry", "LastDiv", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 1, "Apple Inc.", "Technology", 0.22m, 2500000000000L, 150.00m, "AAPL" },
                    { 2, "Microsoft Corporation", "Technology", 0.56m, 2000000000000L, 300.00m, "MSFT" },
                    { 3, "Alphabet Inc.", "Technology", 0.00m, 1800000000000L, 2800.00m, "GOOGL" },
                    { 4, "Amazon.com Inc.", "E-commerce", 0.00m, 1700000000000L, 3500.00m, "AMZN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
