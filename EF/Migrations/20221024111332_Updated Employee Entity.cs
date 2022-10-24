using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGTG_EF.Migrations
{
    public partial class UpdatedEmployeeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
