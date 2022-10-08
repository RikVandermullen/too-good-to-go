using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGTG_EF.Migrations
{
    public partial class FixedEmployeetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Canteens_CanteenId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CanteenId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "CanteenId",
                table: "Employees",
                newName: "Canteen");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeNumber", "Canteen", "EmailAddress", "Name", "Number", "Password" },
                values: new object[] { 1, 3, "kantinemedewerker1@mail.com", "Merel de Laat", 1, "Secret" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Number",
                table: "Employees",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Number",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Canteen",
                table: "Employees",
                newName: "CanteenId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CanteenId",
                table: "Employees",
                column: "CanteenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Canteens_CanteenId",
                table: "Employees",
                column: "CanteenId",
                principalTable: "Canteens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
