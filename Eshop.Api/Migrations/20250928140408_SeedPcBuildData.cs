using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eshop.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedPcBuildData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://via.placeholder.com/150?text=CPU", "CPU" },
                    { 2, "https://via.placeholder.com/150?text=Motherboards", "Motherboards" },
                    { 3, "https://via.placeholder.com/150?text=GPU", "GPU" },
                    { 4, "https://via.placeholder.com/150?text=RAM", "RAM" },
                    { 5, "https://via.placeholder.com/150?text=Storage", "Storage" },
                    { 6, "https://via.placeholder.com/150?text=PSU", "Power Supplies" },
                    { 7, "https://via.placeholder.com/150?text=Cases", "Cases" },
                    { 8, "https://via.placeholder.com/150?text=Cooling", "Cooling" },
                    { 9, "https://via.placeholder.com/150?text=Monitors", "Monitors" },
                    { 10, "https://via.placeholder.com/150?text=Peripherals", "Peripherals" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "High-performance gaming CPU", "https://picsum.photos/seed/cpu/600/400", "AMD Ryzen 7 7800X3D", 399.99m, 10 },
                    { 2, 2, "Gaming motherboard with PCIe 5.0", "https://picsum.photos/seed/motherboard/600/400", "ASUS ROG Strix B650-E", 249.99m, 5 },
                    { 3, 3, "High-end graphics card", "https://picsum.photos/seed/gpu/600/400", "NVIDIA RTX 4080", 1199.99m, 3 },
                    { 4, 4, "Fast DDR5 RAM kit", "https://picsum.photos/seed/ram/600/400", "Corsair Vengeance 32GB DDR5", 149.99m, 20 },
                    { 5, 5, "High-speed NVMe storage", "https://picsum.photos/seed/ssd/600/400", "Samsung 980 Pro 1TB NVMe SSD", 109.99m, 50 },
                    { 6, 6, "80+ Gold certified PSU", "https://picsum.photos/seed/psu/600/400", "Corsair RM850x 850W PSU", 129.99m, 15 },
                    { 7, 7, "Compact ATX case", "https://picsum.photos/seed/case/600/400", "NZXT H510 Case", 79.99m, 8 },
                    { 8, 8, "Air cooler for CPUs", "https://picsum.photos/seed/cooler/600/400", "Noctua NH-D15 Cooler", 99.99m, 12 },
                    { 9, 9, "4K IPS monitor", "https://picsum.photos/seed/monitor/600/400", "Dell Ultrasharp 27\"", 499.99m, 6 },
                    { 10, 10, "Mechanical gaming keyboard", "https://picsum.photos/seed/keyboard/600/400", "Logitech G Pro X Keyboard", 129.99m, 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
