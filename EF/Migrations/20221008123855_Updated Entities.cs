using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGTG_EF.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Packets_PacketId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PacketId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PacketId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HasAlcohol",
                table: "Packets");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Packets",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Canteens",
                columns: new[] { "Id", "City", "Location", "WarmMeals" },
                values: new object[,]
                {
                    { 1, 0, "HA", true },
                    { 2, 0, "LD", true },
                    { 3, 0, "LA", false },
                    { 4, 2, "CHL", true },
                    { 5, 2, "MD", false },
                    { 6, 1, "OWB215", true },
                    { 7, 1, "HP", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packets_ProductName",
                table: "Packets",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "IX_Canteens_Id",
                table: "Canteens",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Packets_Products_ProductName",
                table: "Packets",
                column: "ProductName",
                principalTable: "Products",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packets_Products_ProductName",
                table: "Packets");

            migrationBuilder.DropIndex(
                name: "IX_Packets_ProductName",
                table: "Packets");

            migrationBuilder.DropIndex(
                name: "IX_Canteens_Id",
                table: "Canteens");

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Canteens",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Packets");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "PacketId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasAlcohol",
                table: "Packets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PacketId",
                table: "Products",
                column: "PacketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Packets_PacketId",
                table: "Products",
                column: "PacketId",
                principalTable: "Packets",
                principalColumn: "Id");
        }
    }
}
