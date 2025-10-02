using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cpu.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/motherboards.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/gpu.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/ram.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/storage.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/psu.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cases.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cooling.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/monitors.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/peripherals.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/uncategorized.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cpu.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/motherboards.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/gpu.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/ram.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/storage.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/psu.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cases.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cooling.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/monitors.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/peripherals.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=CPU");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=Motherboards");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=GPU");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=RAM");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=Storage");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=PSU");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=Cases");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=Cooling");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=Monitors");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=Peripherals");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100,
                column: "ImageUrl",
                value: "https://via.placeholder.com/150?text=Uncategorized");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://picsum.photos/seed/cpu/600/400");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://picsum.photos/seed/motherboard/600/400");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://picsum.photos/seed/gpu/600/400");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://picsum.photos/seed/ram/600/400");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://picsum.photos/seed/ssd/600/400");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://picsum.photos/seed/psu/600/400");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://picsum.photos/seed/case/600/400");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://picsum.photos/seed/cooler/600/400");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://picsum.photos/seed/monitor/600/400");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://picsum.photos/seed/keyboard/600/400");
        }
    }
}
