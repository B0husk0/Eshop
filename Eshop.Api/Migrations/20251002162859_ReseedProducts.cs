using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eshop.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReseedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { "High performance CPU model 1", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cpu.jpg", "CPU 1", 220m, 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 1, "High performance CPU model 2", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cpu.jpg", "CPU 2", 240m, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 1, "High performance CPU model 3", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cpu.jpg", "CPU 3", 260m, 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 1, "High performance CPU model 4", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cpu.jpg", "CPU 4", 280m, 9 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 1, "High performance CPU model 5", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cpu.jpg", "CPU 5", 300m, 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 1, "High performance CPU model 6", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cpu.jpg", "CPU 6", 320m, 11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 1, "High performance CPU model 7", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cpu.jpg", "CPU 7", 340m, 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 1, "High performance CPU model 8", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cpu.jpg", "CPU 8", 360m, 13 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 1, "High performance CPU model 9", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cpu.jpg", "CPU 9", 380m, 14 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 1, "High performance CPU model 10", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cpu.jpg", "CPU 10", 400m, 15 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 11, 2, "Reliable motherboard model 1", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/mb.jpg", "Motherboard 1", 165m, 6 },
                    { 12, 2, "Reliable motherboard model 2", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/mb.jpg", "Motherboard 2", 180m, 7 },
                    { 13, 2, "Reliable motherboard model 3", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/mb.jpg", "Motherboard 3", 195m, 8 },
                    { 14, 2, "Reliable motherboard model 4", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/mb.jpg", "Motherboard 4", 210m, 9 },
                    { 15, 2, "Reliable motherboard model 5", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/mb.jpg", "Motherboard 5", 225m, 10 },
                    { 16, 2, "Reliable motherboard model 6", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/mb.jpg", "Motherboard 6", 240m, 11 },
                    { 17, 2, "Reliable motherboard model 7", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/mb.jpg", "Motherboard 7", 255m, 12 },
                    { 18, 2, "Reliable motherboard model 8", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/mb.jpg", "Motherboard 8", 270m, 13 },
                    { 19, 2, "Reliable motherboard model 9", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/mb.jpg", "Motherboard 9", 285m, 14 },
                    { 20, 2, "Reliable motherboard model 10", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/mb.jpg", "Motherboard 10", 300m, 15 },
                    { 21, 3, "Powerful graphics card 1", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/gpu.jpg", "GPU 1", 450m, 4 },
                    { 22, 3, "Powerful graphics card 2", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/gpu.jpg", "GPU 2", 500m, 5 },
                    { 23, 3, "Powerful graphics card 3", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/gpu.jpg", "GPU 3", 550m, 6 },
                    { 24, 3, "Powerful graphics card 4", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/gpu.jpg", "GPU 4", 600m, 7 },
                    { 25, 3, "Powerful graphics card 5", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/gpu.jpg", "GPU 5", 650m, 8 },
                    { 26, 3, "Powerful graphics card 6", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/gpu.jpg", "GPU 6", 700m, 9 },
                    { 27, 3, "Powerful graphics card 7", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/gpu.jpg", "GPU 7", 750m, 10 },
                    { 28, 3, "Powerful graphics card 8", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/gpu.jpg", "GPU 8", 800m, 11 },
                    { 29, 3, "Powerful graphics card 9", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/gpu.jpg", "GPU 9", 850m, 12 },
                    { 30, 3, "Powerful graphics card 10", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/gpu.jpg", "GPU 10", 900m, 13 },
                    { 31, 4, "Fast DDR memory kit 1", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/ram.jpg", "RAM 1", 75m, 11 },
                    { 32, 4, "Fast DDR memory kit 2", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/ram.jpg", "RAM 2", 80m, 12 },
                    { 33, 4, "Fast DDR memory kit 3", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/ram.jpg", "RAM 3", 85m, 13 },
                    { 34, 4, "Fast DDR memory kit 4", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/ram.jpg", "RAM 4", 90m, 14 },
                    { 35, 4, "Fast DDR memory kit 5", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/ram.jpg", "RAM 5", 95m, 15 },
                    { 36, 4, "Fast DDR memory kit 6", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/ram.jpg", "RAM 6", 100m, 16 },
                    { 37, 4, "Fast DDR memory kit 7", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/ram.jpg", "RAM 7", 105m, 17 },
                    { 38, 4, "Fast DDR memory kit 8", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/ram.jpg", "RAM 8", 110m, 18 },
                    { 39, 4, "Fast DDR memory kit 9", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/ram.jpg", "RAM 9", 115m, 19 },
                    { 40, 4, "Fast DDR memory kit 10", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/ram.jpg", "RAM 10", 120m, 20 },
                    { 41, 5, "Reliable SSD/HDD 1", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/storage.jpg", "Storage 1", 100m, 21 },
                    { 42, 5, "Reliable SSD/HDD 2", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/storage.jpg", "Storage 2", 110m, 22 },
                    { 43, 5, "Reliable SSD/HDD 3", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/storage.jpg", "Storage 3", 120m, 23 },
                    { 44, 5, "Reliable SSD/HDD 4", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/storage.jpg", "Storage 4", 130m, 24 },
                    { 45, 5, "Reliable SSD/HDD 5", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/storage.jpg", "Storage 5", 140m, 25 },
                    { 46, 5, "Reliable SSD/HDD 6", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/storage.jpg", "Storage 6", 150m, 26 },
                    { 47, 5, "Reliable SSD/HDD 7", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/storage.jpg", "Storage 7", 160m, 27 },
                    { 48, 5, "Reliable SSD/HDD 8", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/storage.jpg", "Storage 8", 170m, 28 },
                    { 49, 5, "Reliable SSD/HDD 9", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/storage.jpg", "Storage 9", 180m, 29 },
                    { 50, 5, "Reliable SSD/HDD 10", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/storage.jpg", "Storage 10", 190m, 30 },
                    { 51, 6, "Stable PSU unit 1", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/psu.jpg", "Power Supply 1", 90m, 8 },
                    { 52, 6, "Stable PSU unit 2", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/psu.jpg", "Power Supply 2", 100m, 9 },
                    { 53, 6, "Stable PSU unit 3", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/psu.jpg", "Power Supply 3", 110m, 10 },
                    { 54, 6, "Stable PSU unit 4", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/psu.jpg", "Power Supply 4", 120m, 11 },
                    { 55, 6, "Stable PSU unit 5", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/psu.jpg", "Power Supply 5", 130m, 12 },
                    { 56, 6, "Stable PSU unit 6", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/psu.jpg", "Power Supply 6", 140m, 13 },
                    { 57, 6, "Stable PSU unit 7", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/psu.jpg", "Power Supply 7", 150m, 14 },
                    { 58, 6, "Stable PSU unit 8", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/psu.jpg", "Power Supply 8", 160m, 15 },
                    { 59, 6, "Stable PSU unit 9", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/psu.jpg", "Power Supply 9", 170m, 16 },
                    { 60, 6, "Stable PSU unit 10", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/psu.jpg", "Power Supply 10", 180m, 17 },
                    { 61, 7, "Durable PC case 1", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/case.jpg", "Case 1", 65m, 6 },
                    { 62, 7, "Durable PC case 2", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/case.jpg", "Case 2", 70m, 7 },
                    { 63, 7, "Durable PC case 3", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/case.jpg", "Case 3", 75m, 8 },
                    { 64, 7, "Durable PC case 4", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/case.jpg", "Case 4", 80m, 9 },
                    { 65, 7, "Durable PC case 5", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/case.jpg", "Case 5", 85m, 10 },
                    { 66, 7, "Durable PC case 6", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/case.jpg", "Case 6", 90m, 11 },
                    { 67, 7, "Durable PC case 7", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/case.jpg", "Case 7", 95m, 12 },
                    { 68, 7, "Durable PC case 8", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/case.jpg", "Case 8", 100m, 13 },
                    { 69, 7, "Durable PC case 9", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/case.jpg", "Case 9", 105m, 14 },
                    { 70, 7, "Durable PC case 10", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/case.jpg", "Case 10", 110m, 15 },
                    { 71, 8, "Efficient cooling solution 1", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cooling.jpg", "Cooling 1", 55m, 9 },
                    { 72, 8, "Efficient cooling solution 2", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cooling.jpg", "Cooling 2", 60m, 10 },
                    { 73, 8, "Efficient cooling solution 3", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cooling.jpg", "Cooling 3", 65m, 11 },
                    { 74, 8, "Efficient cooling solution 4", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cooling.jpg", "Cooling 4", 70m, 12 },
                    { 75, 8, "Efficient cooling solution 5", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cooling.jpg", "Cooling 5", 75m, 13 },
                    { 76, 8, "Efficient cooling solution 6", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cooling.jpg", "Cooling 6", 80m, 14 },
                    { 77, 8, "Efficient cooling solution 7", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cooling.jpg", "Cooling 7", 85m, 15 },
                    { 78, 8, "Efficient cooling solution 8", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cooling.jpg", "Cooling 8", 90m, 16 },
                    { 79, 8, "Efficient cooling solution 9", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cooling.jpg", "Cooling 9", 95m, 17 },
                    { 80, 8, "Efficient cooling solution 10", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/cooling.jpg", "Cooling 10", 100m, 18 },
                    { 81, 9, "High-resolution monitor 1", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/monitor.jpg", "Monitor 1", 230m, 5 },
                    { 82, 9, "High-resolution monitor 2", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/monitor.jpg", "Monitor 2", 260m, 6 },
                    { 83, 9, "High-resolution monitor 3", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/monitor.jpg", "Monitor 3", 290m, 7 },
                    { 84, 9, "High-resolution monitor 4", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/monitor.jpg", "Monitor 4", 320m, 8 },
                    { 85, 9, "High-resolution monitor 5", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/monitor.jpg", "Monitor 5", 350m, 9 },
                    { 86, 9, "High-resolution monitor 6", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/monitor.jpg", "Monitor 6", 380m, 10 },
                    { 87, 9, "High-resolution monitor 7", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/monitor.jpg", "Monitor 7", 410m, 11 },
                    { 88, 9, "High-resolution monitor 8", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/monitor.jpg", "Monitor 8", 440m, 12 },
                    { 89, 9, "High-resolution monitor 9", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/monitor.jpg", "Monitor 9", 470m, 13 },
                    { 90, 9, "High-resolution monitor 10", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/monitor.jpg", "Monitor 10", 500m, 14 },
                    { 91, 10, "Peripheral device 1", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/peripheral.jpg", "Peripheral 1", 40m, 16 },
                    { 92, 10, "Peripheral device 2", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/peripheral.jpg", "Peripheral 2", 50m, 17 },
                    { 93, 10, "Peripheral device 3", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/peripheral.jpg", "Peripheral 3", 60m, 18 },
                    { 94, 10, "Peripheral device 4", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/peripheral.jpg", "Peripheral 4", 70m, 19 },
                    { 95, 10, "Peripheral device 5", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/peripheral.jpg", "Peripheral 5", 80m, 20 },
                    { 96, 10, "Peripheral device 6", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/peripheral.jpg", "Peripheral 6", 90m, 21 },
                    { 97, 10, "Peripheral device 7", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/peripheral.jpg", "Peripheral 7", 100m, 22 },
                    { 98, 10, "Peripheral device 8", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/peripheral.jpg", "Peripheral 8", 110m, 23 },
                    { 99, 10, "Peripheral device 9", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/peripheral.jpg", "Peripheral 9", 120m, 24 },
                    { 100, 10, "Peripheral device 10", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/products/peripheral.jpg", "Peripheral 10", 130m, 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { "High-performance gaming CPU", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cpu.jpg", "AMD Ryzen 7 7800X3D", 399.99m, 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 2, "Gaming motherboard with PCIe 5.0", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/motherboards.jpg", "ASUS ROG Strix B650-E", 249.99m, 5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 3, "High-end graphics card", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/gpu.jpg", "NVIDIA RTX 4080", 1199.99m, 3 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 4, "Fast DDR5 RAM kit", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/ram.jpg", "Corsair Vengeance 32GB DDR5", 149.99m, 20 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 5, "High-speed NVMe storage", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/storage.jpg", "Samsung 980 Pro 1TB NVMe SSD", 109.99m, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 6, "80+ Gold certified PSU", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/psu.jpg", "Corsair RM850x 850W PSU", 129.99m, 15 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 7, "Compact ATX case", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cases.jpg", "NZXT H510 Case", 79.99m, 8 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 8, "Air cooler for CPUs", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/cooling.jpg", "Noctua NH-D15 Cooler", 99.99m, 12 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 9, "4K IPS monitor", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/monitors.jpg", "Dell Ultrasharp 27\"", 499.99m, 6 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 10, "Mechanical gaming keyboard", "https://raw.githubusercontent.com/B0husk0/Eshop/main/assets/images/peripherals.jpg", "Logitech G Pro X Keyboard", 129.99m, 25 });
        }
    }
}
