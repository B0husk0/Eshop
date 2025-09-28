using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUncategorizedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { 100, "https://via.placeholder.com/150?text=Uncategorized", "Uncategorized" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100);
        }
    }
}
